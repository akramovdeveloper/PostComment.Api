﻿using Application.Api.Common.Exceptions;
using Application.Api.Common.Interfaces;
using Domain.Api.Entities;
using MediatR;

namespace Application.Api.UseCases.Comments.Commands
{
    public class UpdateCommentCommand : IRequest<bool>
    {
        public Guid CommentId { get; init; }
        public string Comment { get; init; }
    }

    public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        private readonly ICurrentUserService _currentUserService;

        public UpdateCommentCommandHandler(IApplicationDbContext context, ICurrentUserService currentUserService)
               => (_context, _currentUserService) = (context, currentUserService);


        public async Task<bool> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Comments
                .FindAsync(new object[] { request.CommentId }, cancellationToken);
            if (entity is null)
                throw new NotFoundException(nameof(Comment), request.CommentId);
            entity.AuthorId = _currentUserService.UserId;
            entity.Content = request.Comment;
            entity.LastUpdated = DateTime.UtcNow;
            entity.LastUpdatedBy = _currentUserService.UserName;

            await _context.SaveChangesAsync(cancellationToken);
            return true;

        }
    }
}
