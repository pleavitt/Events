using Dynamic.Application.Common.Interfaces;
using Dynamic.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Dynamic.Application.Events.Commands.CreateEvent
{
    public partial class CreateEventCommand : IRequest<int>
    {
        public string Name { get; set; }
    }

    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateEventCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            var entity = new Event();

            entity.Name = request.Name;

            _context.Events.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
