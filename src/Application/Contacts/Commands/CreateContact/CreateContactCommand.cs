using Dynamic.Application.Common.Interfaces;
using Dynamic.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Dynamic.Application.Contacts.Commands.CreateContact
{
  public partial class CreateContactCommand : IRequest<int>
  {
    public string Name { get; set; }
  }

  public class CreateContactCommandHandler : IRequestHandler<CreateContactCommand, int>
  {
    private readonly IApplicationDbContext _context;

    public CreateContactCommandHandler(IApplicationDbContext context)
    {
      _context = context;
    }

    public async Task<int> Handle(CreateContactCommand request, CancellationToken cancellationToken)
    {
      var entity = new Contact();

      entity.Name = request.Name;

      _context.Contacts.Add(entity);

      await _context.SaveChangesAsync(cancellationToken);

      return entity.Id;
    }
  }
}
