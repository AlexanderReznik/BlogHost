namespace BlogHost.Domain
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BlogContext : DbContext
    {
        public BlogContext()
            : base("name=BlogContext")
        {
        }

        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Blog>()
                .Property(e => e.UrlSlug)
                .IsUnicode(false);

            modelBuilder.Entity<Blog>()
                .Property(e => e.Date)
                .HasPrecision(0);

            modelBuilder.Entity<Blog>()
                .HasMany(e => e.Posts)
                .WithRequired(e => e.Blog)
                .HasForeignKey(e => e.BlogId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Posts)
                .WithRequired(e => e.Category)
                .HasForeignKey(e => e.CategoryId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Comment>()
                .Property(e => e.Text)
                .IsUnicode(false);

            modelBuilder.Entity<Comment>()
                .Property(e => e.Date)
                .HasPrecision(0);

            modelBuilder.Entity<Post>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<Post>()
                .Property(e => e.UrlSlug)
                .IsUnicode(false);

            modelBuilder.Entity<Post>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Post>()
                .Property(e => e.Text)
                .IsUnicode(false);

            modelBuilder.Entity<Post>()
                .Property(e => e.Date)
                .HasPrecision(0);

            modelBuilder.Entity<Post>()
                .HasMany(e => e.Comments)
                .WithRequired(e => e.Post)
                .HasForeignKey(e => e.PostId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Post>()
                .HasMany(e => e.Tags)
                .WithMany(e => e.Posts)
                .Map(m => m.ToTable("post_has_tag"));

            modelBuilder.Entity<Role>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.role)
                .HasForeignKey(e => e.role_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tag>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.nickname)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Blogs)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Comments)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(false);
        }
    }
}
