using Microsoft.EntityFrameworkCore;
using YouBlog.Infrastructure.BlogPost;

namespace YouBlog.Infrastructure.Database;

public class YouBlogDbContext : DbContext
{
    public YouBlogDbContext(DbContextOptions<YouBlogDbContext> options) : base(options) { }

    public DbSet<BlogPostDAO> BlogPosts { get; set; }
    public DbSet<CommentDAO> Comments { get; set; }

    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     base.OnModelCreating(modelBuilder);
    //
    //     modelBuilder.Entity<BlogPostDAO>(entity =>
    //     {
    //         entity.HasKey(e => e.Id);
    //         entity.Property(e => e.Title).IsRequired().HasMaxLength(200);
    //         entity.Property(e => e.Content).IsRequired();
    //         entity.Property(e => e.CreatedAt).IsRequired();
    //         entity.Property(e => e.UpdatedAt).IsRequired();
    //         entity.HasMany(e => e.Comments)
    //             .WithOne()
    //             .HasForeignKey(c => c.BlogPostId)
    //             .OnDelete(DeleteBehavior.Cascade);
    //     });
    //
    //     modelBuilder.Entity<CommentDAO>(entity =>
    //     {
    //         entity.HasKey(e => e.Id);
    //         entity.Property(e => e.Author).IsRequired().HasMaxLength(100);
    //         entity.Property(e => e.Content).IsRequired();
    //         entity.Property(e => e.CreatedAt).IsRequired();
    //         entity.Property(e => e.BlogPostId).IsRequired();
    //     });
    // }
}