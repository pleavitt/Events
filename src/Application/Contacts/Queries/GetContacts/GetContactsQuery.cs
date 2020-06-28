using AutoMapper;
using AutoMapper.QueryableExtensions;
using Dynamic.Application.Common.Interfaces;
using Dynamic.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Dynamic.Application.Contacts.Queries.GetContacts
{
  public class GetContactsQuery : IRequest<IEnumerable<ContactDto>>
  {
  }

  public class GetContactsQueryHandler : IRequestHandler<GetContactsQuery, IEnumerable<ContactDto>>
  {
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetContactsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }

    public async Task<IEnumerable<ContactDto>> Handle(GetContactsQuery request, CancellationToken cancellationToken)
    {
      return await _context.Contacts
          .ProjectTo<ContactDto>(_mapper.ConfigurationProvider)
          .OrderBy(t => t.Name)
          .ToListAsync(cancellationToken);
    }
  }
}
