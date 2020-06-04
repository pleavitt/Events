using Dynamic.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Dynamic.Application.Events.Commands.CreateEvent
{
    public class CreateEventCommandValidator : AbstractValidator<CreateEventCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreateEventCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(200).WithMessage("Name must not exceed 200 characters.")
                .MustAsync(BeUniqueName).WithMessage("The specified name already exists.");
        }

        public async Task<bool> BeUniqueName(string name, CancellationToken cancellationToken)
        {
            return await _context.Events
                .AllAsync(l => l.Name != name);
        }
    }
}
