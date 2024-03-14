using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Shop.Application.Common.Helpers;
using Shop.Application.Common.Interfaces;
using Shop.Application.Common.Mappers;
using Shop.Application.Common.Models;
using Shop.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Shop.Infrastructure.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;


        public IdentityService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;

        }


        public async Task<ApplicationUser> GetUserByUserName(string userName)
        {
            return await _userManager.FindByNameAsync(userName);
        }

        public async Task<ResponseModel> Register(RegisterModelDto model)
        {
            ApplicationUser user = RegisterModel.ToApplicationUser(model);

            var validationModel = await Validate(model, user);

            if (validationModel.isValid)
            {
                IdentityResult identityResult = await _userManager.CreateAsync(user, model.Password);

                if (identityResult.Errors.Any())
                {
                    var errors = "";

                    foreach (var item in identityResult.Errors)
                    {
                        errors += item.Description + ";";
                    }
                    return new ResponseModel()
                    {
                        isValid = false,
                        ResponseMessage = errors
                    };
                }

                return new ResponseModel()
                {
                    isValid = true,
                    ResponseMessage = "You have successfully registered"
                };
            }
            else
            {
                return new ResponseModel()
                {
                    isValid = false,
                    ResponseMessage = validationModel.ResponseMessage
                };
            }
        }

        public async Task<SignInResponse> SignIn(SignInModelDto model)
        {
            //Validation method for signIn
            var signInResult = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, false);

            if (signInResult.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(model.Username);

                var claims = new Claim[]
               {
                    new Claim(ClaimTypes.NameIdentifier,user.UserName),
                    //new Claim(ClaimTypes.Role,roles[0]),
                    new Claim(ClaimTypes.Country,user.Country)
               };

                var signinKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<string>("SecretKey")));


                var signinCredentials = new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(signingCredentials: signinCredentials, expires: DateTime.UtcNow.AddHours(1), claims: claims);

                return new SignInResponse
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    Username = user.UserName,
                };
            }

            else
            {
                return new SignInResponse
                {
                    Token = string.Empty,
                    Username = string.Empty
                };
            }
        }

        private async Task<ResponseModel> Validate(RegisterModelDto model, ApplicationUser user)
        {
            if (string.IsNullOrEmpty(model.Email) ||
                string.IsNullOrEmpty(model.Password) ||
                string.IsNullOrEmpty(model.Country) ||
                 string.IsNullOrEmpty(model.ConfirmPassword) ||
                 string.IsNullOrEmpty(model.Username))
            {
                return new ResponseModel()
                {
                    isValid = false,
                    ResponseMessage = "Registration failed!"
                };
            }



            var email = await _userManager.FindByEmailAsync(model.Email);

            if (email != null)
            {
                return new ResponseModel()
                {
                    isValid = false,
                    ResponseMessage = "Email exist!"
                };
            }

            var existingUser = await _userManager.FindByNameAsync(model.Username);

            if (existingUser != null)
            {
                return new ResponseModel()
                {
                    isValid = false,
                    ResponseMessage = "Username exist!"
                };
            }

            //if (model.Password != model.ConfirmPassword)
            //{
            //    return new ResponseModel()
            //    {
            //        isValid = false,
            //        ResponseMessage = "Password and Confirm Password doesnt match"
            //    };
            //}

            return new ResponseModel()
            {
                isValid = true
            };

        }
    }
}
