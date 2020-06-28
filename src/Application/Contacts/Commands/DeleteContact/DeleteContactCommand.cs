using Dynamic.Application.Common.Exceptions;
using Dynamic.Application.Common.Interfaces;
using Dynamic.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Dynamic.Application.Contacts.Commands.DeleteContact
{
  public class DeleteContactCommand : IRequest
  {
    public int Id { get; set; }
  }

  public class DeleteContactCommandHandler : IRequestHandler<DeleteContactCommand>
  {
    private readonly IApplicationDbContext _context;

    public DeleteContactCommandHandler(IApplicationDbContext context)
    {
      _context = context;
    }

    public async Task<Unit> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
    {
      var entity = await _context.Contacts
          .Where(l => l.Id == request.Id)
          .SingleOrDefaultAsync(cancellationToken);

      if (entity == null)
      {
        throw new NotFoundException(nameof(Contact), request.Id);
      }

      _context.Contacts.Remove(entity);

      await _context.SaveChangesAsync(cancellationToken);

      return Unit.Value;
    }
  }
}
