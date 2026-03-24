using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer.Entities
{
    public class SavedItem : BaseEntity
    {
        public string Type { get; set; }
        public int UserId { get; set; } 
        public virtual User User { get; set; }
        public int ItemId { get; set; }
        public virtual BaseItemEntity Item { get; set; }
    }
}
