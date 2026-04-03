using Business_Layer.Services;
using Data_Layer.Entities;
using Data_Layer.Entities.Categories;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs.RequestDTOs.Snippet;
using Shared.DTOs.ResponseDTOs.ClassificationDTOs;
using Shared.DTOs.ResponseDTOs.FilterDTOs;
using Shared.DTOs.ResponseDTOs.Snippet;
using System.Linq.Expressions;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SnippetsController : BaseCRUDController<
        Snippet, 
        SnippetServices, 
        SnippetRequest, 
        SnippetGetRequest, 
        SnippetResponseDto>
    {
        public SnippetsController(SnippetServices service) : base(service)
        {
            
        }
        protected override Expression<Func<Snippet, bool>> GetFilter(SnippetGetRequest model)
        {
           
            return null;
        }

        protected override SnippetResponseDto MapToResponse(Snippet s)
        {
            return new SnippetResponseDto
            {
                Id = s.Id,
                Title = s.Title,
                Code = s.Content,

                Category = s.Category == null ? null : new CategoryDto
                {
                    Id = s.Category.Id,
                    Name = s.Category.Name
                },

                Language = s.Language == null ? null : new LanguageDto
                {
                    Id = s.Language.Id,
                    Name = s.Language.Name
                },

                Tags = s.Tags == null
                    ? new List<TagDto>()
                    : s.Tags.Select(t => new TagDto
                    {
                        Id = t.Id,
                        Name = t.Name
                    }).ToList()
            };
        }

        protected override void PopulateEntity(Snippet entity, SnippetRequest model)
        {
            entity.Title = model.Title;
            entity.Content = model.Content;
            //entity.CategoryId = model.CategoryId;
            //entity.LanguageId = model.LanguageId;

            // Tags (many-to-many)
            //entity.Tags = model.TagIds?.Select(id => new Tag { Id = id }).ToList();
        }
    }
}
