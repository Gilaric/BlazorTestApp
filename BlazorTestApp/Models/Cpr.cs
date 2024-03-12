using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorTestApp.Models
{
    public class Cpr
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string? User { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string? CprNr { get; set; }
    }
}
