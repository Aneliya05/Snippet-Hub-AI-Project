using Business_Layer;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Shared.Responses_Handling;

namespace API.Services
{
    public class ServiceResultExtension<T> 
        where T : class, new()
    {
        public static ServiceResult<T> Failure(T data, ModelStateDictionary errors)
        {
            var errorList = new List<Error>();

            foreach(var error in errors)
            {
                if(error.Value.Errors.Count > 0)
                {
                    errorList.Add(new Error
                    {
                        Key = error.Key,
                        Messages = error.Value.Errors.Select(e => e.ErrorMessage).ToList()
                    });
                }
            }   

            return new ServiceResult<T>
            {
                IsSuccess = false,
                Data = data,
                Errors = errorList
            };
        }
    }
}
