using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer.Entities.Categories
{
    public class BaseCategoryEntity : BaseEntity
    {
        public string Name { get; set; }

        public virtual List<Snippet> Snippets { get; set; } = new List<Snippet>();
        public virtual List<Article> Articles { get; set; } = new List<Article>();
    }
}
