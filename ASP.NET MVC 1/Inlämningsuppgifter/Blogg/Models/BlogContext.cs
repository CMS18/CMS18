using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Blogg.Models
{
    public partial class BlogContext : DbContext
    {
        public BlogContext()
        {
        }

        public BlogContext(DbContextOptions<BlogContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BlogPosts> BlogPosts { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=CHEESECAKE; Database=Blog ;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.1-servicing-10028");

            modelBuilder.Entity<BlogPosts>(entity =>
            {
                entity.HasKey(e => e.PostId)
                    .HasName("PK__BlogPost__AA12601826DD1937");

                entity.Property(e => e.CategoryId).HasDefaultValueSql("((1))");

                entity.Property(e => e.DatePosted).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PostBreadText)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.PostContext)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PostHeader)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
                
                entity.HasOne(d => d.Category)
                    .WithMany(p => p.BlogPosts)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__BlogPosts__Categ__3A81B327");
            });

            modelBuilder.Entity<Categories>(entity =>
            {
                entity.HasKey(e => e.CategoryId)
                    .HasName("PK__Categori__19093A0BFE77CD41");

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });
        }
    }
}
