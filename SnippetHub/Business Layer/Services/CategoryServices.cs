using Data_Layer.Entities.Categories;
using Data_Layer.Entities;
using Data_Layer.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Services
{
    public class CategoryServices : BaseServices<Category>
    {
        public CategoryServices(AppDbContext context) : base(context)
        {

        }

        public Category GetCategoryByName(string name)
        {
            return Items.FirstOrDefault(x => x.Name == name);
        }

        public List<Snippet> SearchSnippetsByCategory(string category, string orderBy = null, bool sortAsc = false, int page = 1, int pageSize = int.MaxValue)
        {
            var foundCategory = GetCategoryByName(category);

            if (foundCategory is null)
                throw new Exception("Category is not found!");

            //Context.Attach(foundLanguage);

            var query = foundCategory.Snippets.AsEnumerable();

            if (!string.IsNullOrEmpty(orderBy))
            {
                var property = typeof(Category).GetProperty(orderBy);
                if (property != null)
                {
                    query = sortAsc ? query.OrderBy(p => property.GetValue(p))
                                    : query.OrderByDescending(p => property.GetValue(p));
                }
            }

            return query.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }

        public List<Article> SearchArticlesByLanguage(string category, string orderBy = null, bool sortAsc = false, int page = 1, int pageSize = int.MaxValue)
        {
            var foundCategory = GetCategoryByName(category);

            if (foundCategory is null)
                throw new Exception("Category is not found!");

            //Context.Attach(foundLanguage);

            var query = foundCategory.Articles.AsEnumerable();

            if (!string.IsNullOrEmpty(orderBy))
            {
                var property = typeof(Category).GetProperty(orderBy);
                if (property != null)
                {
                    query = sortAsc ? query.OrderBy(p => property.GetValue(p))
                                    : query.OrderByDescending(p => property.GetValue(p));
                }
            }

            return query.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }
    }
}
