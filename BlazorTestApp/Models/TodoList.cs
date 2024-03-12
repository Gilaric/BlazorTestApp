using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorTestApp.Models
{
    public class TodoList
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "bigint")]
        public int UserId { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string? Item { get; set; }
    }
}
