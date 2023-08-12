﻿using Application.Api.Common.Interfaces;
using Application.Api.Common.Models;
using AutoMapper;
using MediatR;

namespace Application.Api.UseCases.Comments.Queries;

public class GetAllCommentQuery : IRequest<IQueryable<CommentGetDto>>
{
}

public class GetAllCommentQueryHandler : IRequestHandler<GetAllCommentQuery, IQueryable<CommentGetDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    public GetAllCommentQueryHandler(IApplicationDbContext context, IMapper mapper)
           => (_context, _mapper) = (context, mapper);

    public async Task<IQueryable<CommentGetDto>> Handle(GetAllCommentQuery request, CancellationToken cancellationToken)
    {
        var entities = _context.Comments;
        var result = _mapper.ProjectTo<CommentGetDto>(entities);
        return await Task.FromResult(result);
    }
}
