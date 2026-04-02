using API.Infrastructure.RequestDTOs.User;
using API.Services;
using Business_Layer.Services;
using Data_Layer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs.RequestDTOs.User;
using Shared.DTOs.ResponseDTOs.User;
using Shared.Responses_Handling;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserServices _userServices;
        private readonly TokenServices _tokenServices;

        public UsersController(UserServices userServices, TokenServices tokenServices)
        {
            _userServices = userServices;
            _tokenServices = tokenServices;
        }

        private void PopulateEntity(User item, UserRegistrationRequest model, out string error)
        {
            error = null;

            if (_userServices.EmailExists(model.Email, item.Id) || _userServices.UsernameExists(model.Username, item.Id))
            {
                error = "User with such credentials exists";
                return;
            }

            item.Email = model.Email ?? item.Email;
            item.Username = model.Username ?? item.Username;
            item.Password = model.Password ?? item.Password;

        }

        [HttpPost("createToken")]
        public IActionResult CreateToken([FromBody] UserLoginRequest model) // FromBody because MAUI accepts JSON
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(
                    ServiceResultExtension<List<Error>>.Failure(null, ModelState)
                );
            }

            var loggedUser = _userServices.Authenticate(model.Username, model.Password);

            if (loggedUser == null)
            {
                ModelState.AddModelError("Global", "User not found.");
                return Unauthorized(
                    ServiceResultExtension<List<Error>>.Failure(null, ModelState)
                );
            }

            string token = _tokenServices.CreateToken(loggedUser);
            return Ok(ServiceResult<TokenResponse>.Success(new TokenResponse
            {
                Token = token
            }));
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] UserRegistrationRequest model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(
                    ServiceResultExtension<List<Error>>.Failure(null, ModelState)
                );
            }

            try
            {

                var authUser = _userServices.Register(model.Username, model.Email, model.Password);

                var token = _tokenServices.CreateToken(authUser);

                return Ok(ServiceResult<TokenResponse>.Success(new TokenResponse
                {
                    Token = token
                }));
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
        [HttpPut("editAccount")]
        public IActionResult EditAccount([FromBody] UserRegistrationRequest model)
        {
            if (!ModelState.IsValid)
                return BadRequest(
                    ServiceResultExtension<List<Error>>.Failure(null, ModelState)
                );

            int loggedUserId = Convert.ToInt32(this.User.FindFirst("loggedUserId").Value);
            
            var forUpdate = _userServices.GetById(loggedUserId);

            PopulateEntity(forUpdate, model, out string error);
            if (!string.IsNullOrEmpty(error))
            {
                return BadRequest(ServiceResult<UserRegistrationRequest>.Failure(model,
                   new List<Error>
                   {
                        new Error()
                        {
                            Key = "Global",
                            Messages = new List<string>() { error }
                        }
                   }));
            }
            _userServices.Save(forUpdate);

            return Ok(ServiceResult<User>.Success(forUpdate));
        }

        [Authorize]
        [HttpDelete("deleteAccount")]
        public IActionResult Delete()
        {
            int loggedUserId = Convert.ToInt32(this.User.FindFirst("loggedUserId").Value);

            User forDelete = _userServices.GetById(loggedUserId);
            _userServices.Delete(forDelete);

            return Ok(ServiceResult<User>.Success(forDelete));
        }
    }
}
