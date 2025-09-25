using DAL.Data.Entities;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebAppPL.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Biography> Biographies { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<BookCategory> BookCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Author>()
                .HasOne(a => a.Biography)
                .WithOne(b => b.Author)
                .HasForeignKey<Biography>(b => b.AuthorId);

            builder.Entity<Company>()
                .HasMany(c => c.Employees)
                .WithOne(e => e.Company)
                .HasForeignKey(e => e.CompanyId);

            builder.Entity<BookCategory>()
                .HasKey(bc => new {bc.BookId, bc.CategoryId});

            builder.Entity<BookCategory>()
                .HasOne(bc => bc.Category)
                .WithMany(bc => bc.BookCategories)
                .HasForeignKey(bc => bc.CategoryId);

            builder.Entity<BookCategory>()
                .HasOne(bc => bc.Book)
                .WithMany(bc => bc.BookCategories)
                .HasForeignKey(bc => bc.BookId);

            base.OnModelCreating(builder);
        }

    }
}
