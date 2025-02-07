using BookBond.Core.Models;
using BookBond.Infra.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookBond.Infra.Data;

public class AppDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Book> Book { get; set; }
    public DbSet<Comment> Comment { get; set; }
    public DbSet<CommentLikes> CommentLikes { get; set; }
    public DbSet<Post> Post { get; set; }
    public DbSet<PostLikes> PostLikes { get; set; }



    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Adjusting AspNet Identity tables
        builder.Entity<ApplicationUser>(e => { e.ToTable(name: "User"); });
        builder.Entity<IdentityRole>(e => { e.ToTable(name: "Role"); });
        builder.Entity<IdentityRoleClaim<Guid>>(e => { e.ToTable(name: "RoleClaim"); });
        builder.Entity<IdentityUserLogin<Guid>>(e => { e.ToTable(name: "UserLogin"); });
        builder.Entity<IdentityUserClaim<Guid>>(e => { e.ToTable(name: "UserClaim"); });
        builder.Entity<IdentityUserRole<Guid>>(e => { e.ToTable(name: "UserRole"); });
        builder.Entity<IdentityUserToken<Guid>>(e => { e.ToTable(name: "UserToken"); });



        // Creating new tables
        builder.Entity<Post>()
            .HasOne<ApplicationUser>()
            .WithMany()
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Comment>()
            .HasOne<Post>()
            .WithMany()
            .HasForeignKey(p => p.PostId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.Entity<Comment>()
            .HasOne<ApplicationUser>()
            .WithMany()
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<CommentLikes>()
            .HasOne<ApplicationUser>()
            .WithMany()
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.Entity<CommentLikes>()
            .HasOne<Comment>()
            .WithMany()
            .HasForeignKey(p => p.CommentId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<PostLikes>()
            .HasOne<ApplicationUser>()
            .WithMany()
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<PostLikes>()
            .HasOne<Post>()
            .WithMany()
            .HasForeignKey(p => p.PostId)
            .OnDelete(DeleteBehavior.Cascade);


    }

}