﻿using Application.Api.Common.Interfaces;
using Application.Api.Common.Models;
using AutoMapper;
using MediatR;

namespace Application.Api.UseCases.Roles.Queries;

public class GetAllRoleQuery : IRequest<IQueryable<RoleGetDto>>
{
}
public class GetAllRoleQueryHandler : IRequestHandler<GetAllRoleQuery, IQueryable<RoleGetDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    public GetAllRoleQueryHandler(IApplicationDbContext context, IMapper mapper)
          => (_context, _mapper) = (context, mapper);
    public async Task<IQueryable<RoleGetDto>> Handle(GetAllRoleQuery request, CancellationToken cancellationToken)
    {
        var entities = _context.Roles;
        var result = _mapper.ProjectTo<RoleGetDto>(entities);
        return await Task.FromResult(result);
    }
}