using Data_Layer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        protected override void PopulateEntity(User item, UserRequest model)
        {
            item.FirstName = model.FirstName;
            item.LastName = model.LastName;
            item.Sex = model.Sex;
            item.BirthDate = model.BirthDate;
            item.BirthCity = model.BirthCity;
            item.Address = model.Address;
            item.Country = model.Country;
            item.Nationality = model.Nationality;
            item.Details = model.Details;
        }

    }
}
