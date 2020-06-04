using Dynamic.Application.Common.Exceptions;
using Dynamic.Application.Common.Interfaces;
using Dynamic.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Dynamic.Application.Events.Commands.UpdateEvent
{
    public class UpdateEventCommand : IRequest
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

    public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateEventCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Events.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Event), request.Id);
            }

            entity.Name = request.Name;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
