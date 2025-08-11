using Microsoft.EntityFrameworkCore;
using ProjectManegementTool.Models;

namespace ProjectManegementTool.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        { }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<UserProjectMapping> UserProjectMappings { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Roles>().HasData(
                new Roles { Id = 1, RoleName = "Admin" },
                new Roles { Id = 2, RoleName = "Manager" },
                new Roles { Id = 3, RoleName = "Team lead" }
            );


            modelBuilder.Entity<UserProjectMapping>()
            .HasKey(up => new { up.UsersId, up.ProjectId });

            modelBuilder.Entity<UserProjectMapping>()
                .HasOne(up => up.Users)
                .WithMany(u => u.UserProjectMappings)
                .HasForeignKey(up => up.UsersId);

            modelBuilder.Entity<UserProjectMapping>()
                .HasOne(up => up.Project)
                .WithMany(p => p.UserProjectMappings)
                .HasForeignKey(up => up.ProjectId);


        }

    }


}






