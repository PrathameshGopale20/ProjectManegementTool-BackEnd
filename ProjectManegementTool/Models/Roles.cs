using System.ComponentModel.DataAnnotations;

namespace ProjectManegementTool.Models
{
    public class Roles
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? RoleName { get; set; }

        public ICollection<Users> Users { get; set; } 
    }
}




