using Dynamic.Application.Common.Exceptions;
using Dynamic.Application.Common.Interfaces;
using Dynamic.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Dynamic.Application.Events.Commands.DeleteEvent
{
    public class DeleteEventCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteEventCommandHandler : IRequestHandler<DeleteEventCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteEventCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteEventCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Events
                .Where(l => l.Id == request.Id)
                .SingleOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Event), request.Id);
            }

            _context.Events.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
