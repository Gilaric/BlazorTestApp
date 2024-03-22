using BlazorTestApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorTestApp.Data
{
    public class TodoDbContext(DbContextOptions<TodoDbContext> options) : DbContext(options)
    {
        public DbSet<TodoList> TodoLists { get; set; }
        public DbSet<Cpr> Cprs { get; set; }

        // Method to find Cpr by matching User with a TodoList UserId
        public IQueryable<Cpr> FindCprsByTodoListUserId(int todoListCprId)
        {
            return Cprs.Where(c => c.TodoList.Any(t => t.CprId == todoListCprId));
        }

        // Method to find TodoList by ID
        // Create operation
        public void CreateTodoList(TodoList todoList)
        {
            TodoLists.Add(todoList);
            SaveChanges();
        }

        public TodoList? FindTodoListById(int id)
        {
            return TodoLists.FirstOrDefault(t => t.ToDoListId == id);
        }

        public void RemoveLast()
        {
            // Retrieve the last item from TodoLists
            var lastItem = TodoLists.OrderBy(t => t.ToDoListId).LastOrDefault();

            // Remove the last item if it exists
            if (lastItem != null)
            {
                TodoLists.Remove(lastItem);

                // Save changes to the database
                SaveChanges();
            }
        }

        // Method to find Cpr by ID
        public Cpr? FindCprById(int id)
        {
            return Cprs.FirstOrDefault(c => c.CprId == id);
        }
        // Create operation for Cpr
        public void CreateCpr(Cpr cpr)
        {
            Cprs.Add(cpr);
            SaveChanges();
        }
    }
}
