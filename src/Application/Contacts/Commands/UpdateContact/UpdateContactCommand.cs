using Dynamic.Application.Common.Exceptions;
using Dynamic.Application.Common.Interfaces;
using Dynamic.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Dynamic.Application.Contacts.Commands.UpdateContact
{
  public class UpdateContactCommand : IRequest
  {
    public int Id { get; set; }

    public string Name { get; set; }
  }

  public class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand>
  {
    private readonly IApplicationDbContext _context;

    public UpdateContactCommandHandler(IApplicationDbContext context)
    {
      _context = context;
    }

    public async Task<Unit> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
    {
      var entity = await _context.Contacts.FindAsync(request.Id);

      if (entity == null)
      {
        throw new NotFoundException(nameof(Contact), request.Id);
      }

      entity.Name = request.Name;

      await _context.SaveChangesAsync(cancellationToken);

      return Unit.Value;
    }
  }
}
