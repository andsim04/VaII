using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VaII_Sem.Models;

namespace VaII.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        
        public DbSet<Settings> Settings { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Settings>().ToTable("Settings");
            modelBuilder.Entity<Post>().ToTable("Posts");


            //modelBuilder.Entity<Post>()
            //    .HasKey(nameof(Post.ID), nameof(Post.UserID));
        }
        public DbSet<VaII_Sem.Models.Post> Post { get; set; } = default!;
    }
}