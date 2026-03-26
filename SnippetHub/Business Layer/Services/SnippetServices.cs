using Data_Layer.Entities;
using Data_Layer.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Services
{
    public class SnippetServices : BaseServices<Snippet>
    {
        public SnippetServices(AppDbContext context) : base(context)
        {
        }
    }
}
