using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer.Entities
{
    public class User : BaseEntity
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual List<Snippet> Snippets { get; set; } = new List<Snippet>();
        public virtual List<Article> Articles { get; set; } = new List<Article>();
        public virtual List<SavedSnippet> SavedSnippets { get; set; } = new List<SavedSnippet>();
        public virtual List<SavedArticle> SavedArticles { get; set; }
    }
}
