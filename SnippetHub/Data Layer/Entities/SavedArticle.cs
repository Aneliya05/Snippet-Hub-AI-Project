using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer.Entities
{
    public class SavedArticle : BaseEntity
    {
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int ArticleId { get; set; }
        public virtual Article Article { get; set; }
    }
}
