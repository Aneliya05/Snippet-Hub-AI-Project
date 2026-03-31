using Data_Layer.Entities;
using Data_Layer.Entities.Categories;
using Data_Layer.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Services
{
    public class LanguageServices : BaseServices<Language>
    {
        public LanguageServices(AppDbContext context) : base(context)
        {
            
        }

        public Language GetLanguageByName(string name)
        {
            return Items.FirstOrDefault(x => x.Name == name);
        }

        public List<Snippet> SearchSnippetsByLanguage(string language, string orderBy = null, bool sortAsc = false, int page = 1, int pageSize = int.MaxValue)
        {
            var foundLanguage = GetLanguageByName(language);

            if (language is null)
                throw new Exception("Language is not found!");

            //Context.Attach(foundLanguage);

            var query = foundLanguage.Snippets.AsEnumerable();

            if (!string.IsNullOrEmpty(orderBy))
            {
                var property = typeof(Language).GetProperty(orderBy);
                if (property != null)
                {
                    query = sortAsc ? query.OrderBy(p => property.GetValue(p))
                                    : query.OrderByDescending(p => property.GetValue(p));
                }
            }

            return query.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }

        public List<Article> SearchArticlesByLanguage(string language, string orderBy = null, bool sortAsc = false, int page = 1, int pageSize = int.MaxValue)
        {
            var foundLanguage = GetLanguageByName(language);

            if (foundLanguage is null)
                throw new Exception("Language is not found!");

            //Context.Attach(foundLanguage);

            var query = foundLanguage.Articles.AsEnumerable();

            if (!string.IsNullOrEmpty(orderBy))
            {
                var property = typeof(Language).GetProperty(orderBy);
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
