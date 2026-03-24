using Data_Layer.Entities.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public DateOnly DatePublished { get; set; }
        public Category Category { get; set; }
        public List<Tag> Tags { get; set; } = new List<Tag>();
        public Language Language { get; set; }
    }
}
