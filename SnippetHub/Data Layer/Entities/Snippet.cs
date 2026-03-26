using Data_Layer.Entities.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer.Entities
{
    public class Snippet : BaseItemEntity
    {
        public int AuthorId { get; set; }

        public int CategoryId { get; set; }
        public int LanguageId { get; set; }
        public virtual User Author { get; set; }
        public virtual Category Category { get; set; }
        public virtual Language Language { get; set; }
        public virtual List<Tag> Tags { get; set; } = new List<Tag>();
    }
}
