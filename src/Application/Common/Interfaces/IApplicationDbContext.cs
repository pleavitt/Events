using Dynamic.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Dynamic.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<TodoList> TodoLists { get; set; }

        DbSet<TodoItem> TodoItems { get; set; }
        DbSet<Event> Events { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
