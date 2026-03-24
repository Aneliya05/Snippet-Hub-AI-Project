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
       public virtual List<Tag> Tags { get; set; } = new List<Tag>();
    }
}
