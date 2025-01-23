using Microsoft.EntityFrameworkCore;
using YouBlog.Infrastructure.BlogPost;

namespace YouBlog.Infrastructure.Database;

public class YouBlogDbContext : DbContext
{
    public YouBlogDbContext(DbContextOptions<YouBlogDbContext> options) : base(options) { }

    public DbSet<BlogPostDAO> BlogPosts { get; set; }
    public DbSet<CommentDAO> Comments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase(databaseName: "YouBlogDB");
        
        base.OnConfiguring(optionsBuilder);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    
        modelBuilder.Entity<BlogPostDAO>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });
    
        modelBuilder.Entity<CommentDAO>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });
    }
}