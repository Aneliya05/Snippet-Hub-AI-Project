using API.Services;
using Business_Layer.Services;
using Business_Layer;
using Data_Layer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using System.Reflection;
using Shared.DTOs.ResponseDTOs.Shared;
using Shared.DTOs.RequestDTOs.Shared;
using Shared.Responses_Handling;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseCRUDController<TEntity, TService, TRequest, TGetRequest, TResponse> : ControllerBase
        where TEntity : BaseEntity, new()
        where TService : BaseServices<TEntity>
        where TRequest : class, new()
        where TGetRequest : BaseGetRequest, new()
        where TResponse : class, new()
    {
        protected readonly TService _service;

        public BaseCRUDController(TService service)
        {
            _service = service;
        }
        protected virtual void PopulateEntity(TEntity item, TRequest model)
        {

        }

        protected virtual Expression<Func<TEntity, bool>> GetFilter(TGetRequest model)
        {
            return null;
        }

        protected virtual Expression<Func<TEntity, bool>> GetPersonalFilter(TGetRequest model)
        {
            return null;
        }
        protected virtual void PopulateGetResponse(TGetRequest request, BaseGetResponse<TResponse> response)
        {

        }

        protected virtual TResponse MapToResponse(TEntity entity)
        {
            throw new NotImplementedException("You must override MapToResponse in the derived controller.");
        }

        [HttpGet("getAll")]
        public virtual IActionResult Get([FromQuery] TGetRequest model)
        {
            model.Pager = model.Pager ?? new PagerRequest();
            model.Pager.Page = model.Pager.Page <= 0
                                    ? 1
                                    : model.Pager.Page;
            model.Pager.PageSize = model.Pager.PageSize <= 0
                                        ? 10
                                        : model.Pager.PageSize;

            model.OrderBy ??= nameof(BaseEntity.Id);
            model.OrderBy = typeof(TEntity).GetProperty(model.OrderBy) != null
                                ? model.OrderBy
                                : nameof(BaseEntity.Id);

            //EService service = new EService();

            Expression<Func<TEntity, bool>> filter = GetFilter(model);

            var response = new BaseGetResponse<TResponse>
            {
                Pager = new PagerResponse
                {
                    Page = model.Pager.Page,
                    PageSize = model.Pager.PageSize
                },
                OrderBy = model.OrderBy,
                SortAscending = model.SortAscending
            };

            PopulateGetResponse(model, response);

            response.Pager.Count = _service.Count(filter);

            var entities = _service.GetAll(
                filter,
                model.OrderBy,
                model.SortAscending,
                model.Pager.Page,
                model.Pager.PageSize
            );

            response.Items = entities
               .Select(MapToResponse)
               .ToList();

            return Ok(ServiceResult<BaseGetResponse<TResponse>>.Success(response));
        }

        [HttpGet("getById")]
        [Route("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            //EService service = new EService();
            try
            {
                var item = _service.GetById(id);

                if (item == null)
                    throw new Exception($"{typeof(TEntity).Name} not found");
                return Ok(ServiceResult<TResponse>.Success(MapToResponse(item)));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Global", ex.Message);
                return BadRequest(
                    ServiceResultExtension<List<Error>>.Failure(null, ModelState)
                );
            }
        }

        [Authorize]
        [HttpPost]
        public virtual IActionResult Post([FromBody] TRequest model)
        {
            if (!ModelState.IsValid)
                return BadRequest(
                    ServiceResultExtension<List<Error>>.Failure(null, ModelState)
                );

            //EService service = new EService();
            TEntity item = new TEntity();

            PopulateEntity(item, model);

            _service.Save(item);
            return Ok(ServiceResult<TResponse>.Success(MapToResponse(item)));
        }

        [Authorize]
        [HttpPut]
        [Route("{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] TRequest model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(
                        ServiceResultExtension<List<Error>>.Failure(null, ModelState)
                    );
            }
            //EService service = new EService();
            try
            {
                TEntity forUpdate = _service.GetById(id);
                if (forUpdate == null)
                    throw new Exception($"{typeof(TEntity).Name} not found");

                PopulateEntity(forUpdate, model);

                _service.Save(forUpdate);
                
                return Ok(ServiceResult<TResponse>.Success(MapToResponse(forUpdate)));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Global", ex.Message);
                return BadRequest(
                    ServiceResultExtension<List<Error>>.Failure(null, ModelState)
                );
            }
        }

        [Authorize]
        [HttpDelete]
        [Route("{id}")]

        public IActionResult Delete([FromRoute] int id)
        {
            //EService service = new EService();
            try
            {
                TEntity forDelete = _service.GetById(id);
                
                if (forDelete == null)
                    throw new Exception($"{typeof(TEntity).Name} not found");

                _service.Delete(forDelete);

                return Ok(ServiceResult<TResponse>.Success(MapToResponse(forDelete)));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Global", ex.Message);
                return BadRequest(
                    ServiceResultExtension<List<Error>>.Failure(null, ModelState)
                );
            }

        }
    }
}
