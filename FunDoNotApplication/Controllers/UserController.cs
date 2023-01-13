using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;

namespace FunDoNotApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserBL objIUserBL;
        public UserController(IUserBL objIUserBL)
        {
            this.objIUserBL = objIUserBL;
        }
        [HttpPost]
        [Route("UserRegistration")]
        public IActionResult Register(UserRegistration userRegistration)
        {
            try
            {
                var result = objIUserBL.UserRegister(userRegistration);
                if (result != null)
                {
                    return this.Ok(new { success = true, message = "Registration Successfull", data = result });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Registration UnSuccessfull", });
                }
            }
            catch(System.Exception){
                throw;
            }
        }
        [HttpPost]
        [Route("UserLogin")]
        public IActionResult Login(UserLogin userLogin)
        {
            try
            {
                var result= objIUserBL.Login(userLogin);
                if (result != null)
                {
                    return this.Ok(new { success = true, message = "Login Successfull", data = result });
                }
                else
                {
                    return this.NotFound(new { success = false, message = "Login UnSuccessfull", });
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        [HttpPost]
        [Route("ForgotPassword")]
        public IActionResult ForgotPassword(string email)
        {
            try
            {
                var result = objIUserBL.ForgotPassword(email);
                if (result != null)
                {
                    return this.Ok(new { success = true, message = "Mail Sent Successfull", data = result });
                }
                else
                {
                    return this.NotFound(new { success = false, message = "Mail Sent UnSuccessfull", });
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }
        [Authorize]
        [HttpPut]
        [Route("ResetPassword")]
        public IActionResult PasswordReset(string new_password, string confirm_password)
        {
            try
            {
                //var email = User.Claims.First(x => x.Type == "email").Value;
                var email = User.FindFirst(ClaimTypes.Email).Value.ToString();
                var result = objIUserBL.ResetPassword(email, new_password, confirm_password);
                if (result==true)
                {
                    return this.Ok(new { success = true, message = "Password Reset Successfull", data = result });
                }
                else
                {
                    return this.NotFound(new { success = false, message = "Password Reset Failed", });
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
