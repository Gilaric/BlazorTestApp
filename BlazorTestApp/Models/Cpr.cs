using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorTestApp.Models
{
    public class Cpr
    {
        [Key]
        public int CprId { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string? UserName { get; set; }

        [Column(TypeName = "nvarchar(4000)")]
        public string? CprNr { get; set; }

        public ICollection<TodoList> TodoList { get; set; } = new List<TodoList>();
    }
}
