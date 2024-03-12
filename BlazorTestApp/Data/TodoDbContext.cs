using BlazorTestApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorTestApp.Data
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options)
        {
        }

        public DbSet<TodoList> TodoLists { get; set; }
        public DbSet<Cpr> Cprs { get; set; }
    }
}
