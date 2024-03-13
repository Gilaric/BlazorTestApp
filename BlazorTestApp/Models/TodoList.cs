using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorTestApp.Models
{
    public class TodoList
    {
        [Key]
        public int ToDoListId { get; set; }

        [ForeignKey("Cpr")]
        public int CprId { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string? Item { get; set; }

        // Navigation property
        public Cpr Cpr { get; set; } 
    }
}
