using System.Net.Mime;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VaII.Models;
using VaII_Sem.Models;

namespace VaII.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public ApplicationDbContext()
        {
        }


        public DbSet<Post> Posts { get; set; }

        public DbSet<ApplicationUser> Users { get; set; }

        public DbSet<Location> Locations { get; set; }
        public DbSet<AdvancedSettings> AdvancedSettings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ApplicationUser>().ToTable("Users"); ;
            modelBuilder.Entity<Post>().ToTable("Posts");
            modelBuilder.Entity<Location>().ToTable("Locations");
            modelBuilder.Entity<AdvancedSettings>().ToTable("AdvancedSettings");


            //modelBuilder.Entity<Post>()
            //    .HasKey(nameof(Post.ID), nameof(Post.UserID));
        }

        internal Task FirstOrDefaultAsync()
        {
            throw new NotImplementedException();
        }

        public DbSet<VaII_Sem.Models.Post> Post { get; set; } = default!;
    }
}