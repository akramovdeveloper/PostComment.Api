﻿using Application.Api.Common.Exceptions;
using Application.Api.Common.Interfaces;
using Domain.Api.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Api.UseCases.Users.Commands
{
    public class DeleteUserCommand : IRequest<bool>
    {
        public Guid UserId { get; init; }
    }

    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, bool>
    {
        private readonly IApplicationDbContext _context;
        public DeleteUserCommandHandler(IApplicationDbContext context)
            => _context = context;

        public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Users
            .FindAsync(new object[] { request.UserId }, cancellationToken);
            if (entity is null)
                throw new NotFoundException(nameof(User), request.UserId);

            _context.Users.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
