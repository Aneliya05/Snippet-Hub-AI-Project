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

        public DbSet<SavedSnippet> SavedSnippets { get; set; }
        public DbSet<SavedArticle> SavedArticles { get; set; }
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

            modelBuilder.Entity<Article>()
                .HasMany(s => s.Tags)
                .WithMany(t => t.Articles);

            #endregion

            #region Saved Snippet
            modelBuilder.Entity<User>()
                .HasMany(u => u.SavedSnippets)
                .WithMany(s => s.UsersSavingSnippet)
                .UsingEntity<SavedSnippet>(
                    ss => ss
                        .HasOne(ss => ss.Snippet)
                        .WithMany()
                        .HasForeignKey(ss => ss.SnippetId)
                        .OnDelete(DeleteBehavior.Cascade),

                    ss => ss
                        .HasOne(ss => ss.User)
                        .WithMany()
                        .HasForeignKey(ss => ss.UserId)
                        .OnDelete(DeleteBehavior.Cascade),

                    ss => ss.HasKey(t => new { t.UserId, t.SnippetId })
             );

            #endregion

            #region Saved Article
            modelBuilder.Entity<User>()
                .HasMany(u => u.SavedArticles)
                .WithMany(s => s.UsersSavingArticle)
                .UsingEntity<SavedArticle>(
                    sa => sa
                        .HasOne(sa => sa.Article)
                        .WithMany()
                        .HasForeignKey(sa => sa.ArticleId)
                        .OnDelete(DeleteBehavior.Cascade),

                    sa => sa
                        .HasOne(sa => sa.User)
                        .WithMany()
                        .HasForeignKey(sa => sa.UserId)
                        .OnDelete(DeleteBehavior.Cascade),

                    sa => sa.HasKey(t => new { t.UserId, t.ArticleId })
                );
            #endregion
        }
    }
}
