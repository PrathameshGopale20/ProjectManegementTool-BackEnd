using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ProjectManegementTool.Models
{
    public class UserProjectMapping
    {

        [ForeignKey("Users")]
        public int UsersId { get; set; }

        [ForeignKey("Project")]
        public int ProjectId { get; set; }

   
        public Users? Users { get; set; }
        public Project? Project { get; set; }

        public string? AssignedRole { get; set; }
        public DateTime AssignedDate { get; set; } = DateTime.UtcNow;
    }
}
