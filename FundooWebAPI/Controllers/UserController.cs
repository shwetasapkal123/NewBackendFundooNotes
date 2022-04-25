using Buisness_Layer.Interface;
using Database_Layer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository_Layer.Context;
using System;
using System.Linq;

namespace FundooWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    
    public class UserController : ControllerBase
    {
        //instance variable
        IUserBL userBL;
        FundooContext fundoo;
        public UserController(IUserBL userBL, FundooContext fundoo)
        {
            this.userBL = userBL;
            this.fundoo = fundoo;
        }
        [HttpPost("register")]
        public ActionResult RegisterUser(UserPostModel user)
        {
            try
            {
                var getUserData = fundoo.Users.FirstOrDefault(u => u.Email == user.Email);
                if (getUserData != null)
                {
                    return this.Ok(new { success = false, message = $"{user.Email} is Already Exists" });
                }
                this.userBL.AddUser(user);
                return this.Ok(new { success = true, message = $"Registration Successfull { user.Email}" });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost("Login")]
        public ActionResult LoginUser(string Email, string Password)
        {
            try
            {
                var result = this.userBL.LoginUser(Email, Password);
                if (result != null)
                {
                    return this.Ok(new
                    {
                        success = true,
                        message = $"Login Successful " +
                        $" token:  {result}"
                    });

                }
                return this.BadRequest(new { success = false, message = $"Login Failed" });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //[HttpPost("ForgotPassword")]
        //public IActionResult ForgotPassword(string email)
        //{
        //    try
        //    {
        //        var result = userBL.ForgetPassword(email);
        //        if (result == true)
        //            return this.Ok(new { success = true, message = "Reset link send Successfully on registered Email" + result });
        //        else
        //            return this.BadRequest(new { success = false, message = "Reset link UnSuccessful for mail" + result });
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        [HttpPost("ForgetPassword")]
        public IActionResult ForgetPassword(string email)
        {
            try
            {
                var result = this.userBL.ForgetPassword(email);
                if (result != false)
                {
                    return this.Ok(new
                    {
                        success = true,
                        message = $"Mail Sent Successfully " +
                        $" token:  {result}"
                    });

                }
                return this.BadRequest(new { success = false, message = $"mail not sent" });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [Authorize]
        [HttpPut("ChangePassword")]
        public IActionResult ChangePassword(string password, string confirmpassword)
        {
            try
            {
                //var email = User.FindFirst(ClaimTypes.Email).Value.ToString();
                var currentUser = HttpContext.User;
                int userId = Convert.ToInt32(currentUser.Claims.FirstOrDefault(c => c.Type == "UserId").Value);
                var email = (currentUser.Claims.FirstOrDefault(c => c.Type == "Email").Value);
                //var userid = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("userId", StringComparison.InvariantCultureIgnoreCase));
                //int userId = Int32.Parse(userid.Value);
                bool res = userBL.ChangePassword(email, password, confirmpassword);

                if (!res)
                {
                    return this.BadRequest(new { success = false, message = "enter valid password" });

                }
                else
                {
                    return this.Ok(new { success = true, message = "reset password set successfully" });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
