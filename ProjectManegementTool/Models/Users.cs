using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManegementTool.Models
{
    public class Users
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public DateOnly DOB { get; set; }

        public string Designation { get; set; }

        [Required]
        public string Profile_Img { get; set; } = "default.png"; 

        public DateTime Created_At { get; set; } = DateTime.UtcNow;

        public DateTime Updated_At { get; set; } = DateTime.UtcNow;

        [ForeignKey("Roles")]
        public int RolesId { get; set; }

        public Roles Roles { get; set; }

        public ICollection<UserProjectMapping> UserProjectMappings { get; set; }

    }
}






