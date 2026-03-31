using Data_Layer.Entities;
using Data_Layer.Entities.Categories;
using Data_Layer.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Services
{
    public class TagServices : BaseServices<Tag>
    {
        public TagServices(AppDbContext context) : base(context)
        {
            
        }

        public Tag GetTagByName(string name)
        {
            return Items.FirstOrDefault(x => x.Name == name);
        }

        #region Tag/Snippet
        public void AddTagToSnippet(string tag, Snippet snippet)
        {
            Context.Attach(snippet);
            var foundTag = GetTagByName(tag);
            snippet.Tags.Add(foundTag);

            Context.SaveChanges();
        }

        public void RemoveTagFromSnippet(string tag, Snippet snippet)
        {
            Context.Attach(snippet);
            
            var foundTag = GetTagByName(tag);
            snippet.Tags.Remove(foundTag);
            
            Context.SaveChanges();
        }

        public List<Snippet> SearchSnippetsByTag(string tag, string orderBy = null, bool sortAsc = false, int page = 1, int pageSize = int.MaxValue)
        {
            var foundTag = GetTagByName(tag);

            if (foundTag is null)
                throw new Exception("Tag is not found!");

            Context.Attach(foundTag);
            
            var query = foundTag.Snippets.AsEnumerable();

            if (!string.IsNullOrEmpty(orderBy))
            {
                var property = typeof(Tag).GetProperty(orderBy);
                if (property != null)
                {
                    query = sortAsc ? query.OrderBy(p => property.GetValue(p))
                                    : query.OrderByDescending(p => property.GetValue(p));
                }
            }

            return query.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }

        #endregion

        #region Tag/Article
        public void AddTagToArticle(string tag, Article article)
        {
            Context.Attach(article);
            var foundTag = GetTagByName(tag);
            article.Tags.Add(foundTag);

            Context.SaveChanges();
        }

        public void RemoveTagFromArticle(string tag, Article article)
        {
            Context.Attach(article);

            var foundTag = GetTagByName(tag);
            article.Tags.Remove(foundTag);

            Context.SaveChanges();
        }

        public List<Article> SearchArticlesByTag(string tag, string orderBy = null, bool sortAsc = false, int page = 1, int pageSize = int.MaxValue)
        {
            var foundTag = GetTagByName(tag);

            if (foundTag is null)
                throw new Exception("Tag is not found!");

            Context.Attach(foundTag);

            var query = foundTag.Articles.AsEnumerable();

            if (!string.IsNullOrEmpty(orderBy))
            {
                var property = typeof(Tag).GetProperty(orderBy);
                if (property != null)
                {
                    query = sortAsc ? query.OrderBy(p => property.GetValue(p))
                                    : query.OrderByDescending(p => property.GetValue(p));
                }
            }

            return query.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }

        #endregion
    }
}
