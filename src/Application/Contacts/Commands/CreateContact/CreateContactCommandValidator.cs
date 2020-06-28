using Dynamic.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Dynamic.Application.Contacts.Commands.CreateContact
{
  public class CreateContactCommandValidator : AbstractValidator<CreateContactCommand>
  {
    private readonly IApplicationDbContext _context;

    public CreateContactCommandValidator(IApplicationDbContext context)
    {
      _context = context;

      RuleFor(v => v.Name)
          .NotEmpty().WithMessage("Name is required.")
          .MaximumLength(70).WithMessage("Name must not exceed 70 characters.")
          .MustAsync(BeUniqueName).WithMessage("A contact with that name already exists.");
    }

    public async Task<bool> BeUniqueName(string name, CancellationToken cancellationToken)
    {
      return await _context.Contacts
          .AllAsync(l => l.Name != name);
    }
  }
}
