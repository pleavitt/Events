using Dynamic.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Dynamic.Application.Contacts.Commands.UpdateContact
{
  public class UpdateContactCommandValidator : AbstractValidator<UpdateContactCommand>
  {
    private readonly IApplicationDbContext _context;

    public UpdateContactCommandValidator(IApplicationDbContext context)
    {
      _context = context;

      RuleFor(v => v.Name)
          .NotEmpty().WithMessage("Name is required.")
          .MaximumLength(70).WithMessage("Name must not exceed 70 characters.")
          .MustAsync(BeUniqueName).WithMessage("A contact with this name already exists.");
    }

    public async Task<bool> BeUniqueName(UpdateContactCommand model, string name, CancellationToken cancellationToken)
    {
      return await _context.Contacts
          .Where(l => l.Id != model.Id)
          .AllAsync(l => l.Name != name);
    }
  }
}
