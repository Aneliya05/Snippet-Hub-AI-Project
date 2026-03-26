using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer.Entities
{
    public class SavedSnippet : BaseEntity
    {
        public int UserId { get; set; } 
        public virtual User User { get; set; }
        public int SnippetId { get; set; }
        public virtual Snippet Snippet { get; set; }
    }
}
