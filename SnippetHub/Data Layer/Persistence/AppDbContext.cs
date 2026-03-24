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
    }
}
