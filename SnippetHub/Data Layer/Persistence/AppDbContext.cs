using Data_Layer.Entities;
using Data_Layer.Entities.Categories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Snippet> Snippets { get; set; }
        public DbSet<Article> Articles { get; set; }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Language> Languages { get; set; }  
        public DbSet<Tag> Tags { get; set; }

        public DbSet<SavedItem> SavedItems { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseLazyLoadingProxies().UseSqlite(@"Data Source=app.db");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region User
            modelBuilder.Entity<User>()
                .HasData(new User
                {
                    Id = 1,
                    Email = "admin@gmail.com",
                    Username = "admincheto",
                    Password = "adminpass",
                    FirstName = "Admin",
                    LastName = "Adminov"
                });

  
            #endregion

            #region Code Snippet
            modelBuilder.Entity<Snippet>()
                .HasOne(s => s.Category)
                .WithMany(c => c.Snippets)
                .HasForeignKey(s => s.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Snippet>()
                .HasOne(s => s.Language)
                .WithMany(c => c.Snippets)
                .HasForeignKey(s => s.LanguageId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Snippet>()
                .HasOne(s => s.Author)
                .WithMany(a => a.Snippets)
                .HasForeignKey(s => s.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Snippet>()
                .HasMany(s => s.Tags)
                .WithMany(t => t.Snippets);

            #endregion

            #region Article
            modelBuilder.Entity<Article>()
                .HasOne(s => s.Category)
                .WithMany(c => c.Articles)
                .HasForeignKey(s => s.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Article>()
                .HasOne(s => s.Language)
                .WithMany(c => c.Articles)
                .HasForeignKey(s => s.LanguageId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Article>()
                .HasOne(s => s.Author)
                .WithMany(a => a.Articles)
                .HasForeignKey(s => s.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Snippet>()
                .HasMany(s => s.Tags)
                .WithMany(t => t.Snippets);

            #endregion

            #region Saved Item
            modelBuilder.Entity<SavedItem>()
                .HasOne(si => si.User)
                .WithMany(i => i.SavedItems)
                .HasForeignKey(si => si.UserId);

            modelBuilder.Entity<SavedItem>()
                .HasOne(si => si.Item)
                .WithOne()
                .HasForeignKey<SavedItem>(si => si.ItemId);
            #endregion
        }
    }
}
