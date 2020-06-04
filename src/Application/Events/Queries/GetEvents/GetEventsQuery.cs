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

namespace Dynamic.Application.Events.Queries.GetEvents
{
    public class GetEventsQuery : IRequest<IEnumerable<EventDto>>
    {
    }

    public class GetEventsQueryHandler : IRequestHandler<GetEventsQuery, IEnumerable<EventDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetEventsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EventDto>> Handle(GetEventsQuery request, CancellationToken cancellationToken)
        {
                return await _context.Events
                    .ProjectTo<EventDto>(_mapper.ConfigurationProvider)
                    .OrderByDescending(t => t.TimeStart)
                    .ToListAsync(cancellationToken);
        }
    }
}
