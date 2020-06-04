using Dynamic.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Dynamic.Application.Events.Commands.UpdateEvent
{
    public class UpdateEventCommandValidator : AbstractValidator<UpdateEventCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateEventCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(200).WithMessage("Name must not exceed 200 characters.")
                .MustAsync(BeUniqueName).WithMessage("The specified name is already exists.");
        }

        public async Task<bool> BeUniqueName(UpdateEventCommand model, string name, CancellationToken cancellationToken)
        {
            return await _context.Events
                .Where(l => l.Id != model.Id)
                .AllAsync(l => l.Name != name);
        }
    }
}
