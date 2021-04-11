using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Wage.Core.Entities;
using Wage.Core.Interfaces.IServices;
using Wage.Web.DTOs;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Http;
using Wage.Web.Extensions;
using Wage.Web.Models;
using User = Wage.Core.Entities.User;
using BC = BCrypt.Net.BCrypt;
using System.Net.Mail;
using System.Net;
using Wage.Core.EmailService;
using Wage.Web.Functionality;
using Microsoft.Extensions.Options;
using System.Security.Cryptography;
using AutoMapper;

namespace Wage.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userSVC;
        private readonly IRoleService _roleSVC;
        private readonly IUserRoleService _userRolesSVC;
        private readonly IRoleAccessService _roleAccessSVC;
        private readonly IAccessLinkService _accessLinkSVC;
        private readonly IEmailSender _emailSender;
        private string BaseUrl => $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}";

        //private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly EmailConfiguration _emailConfiguration;
        ResponseAPI<string> response = new ResponseAPI<string>();
        public AccountController(
            IUserService userSVC
            , IRoleService roleSVC
            , IUserRoleService userRolesSVC
            , IRoleAccessService roleAccessSVC
            , IAccessLinkService accessLinkSVC
            //, IHttpContextAccessor httpContextAccessor
            , IConfiguration configuration
            , IMapper mapper
            , IEmailSender emailSender
            , IOptions<EmailConfiguration> emailConfiguration
            )

        {
            _userSVC = userSVC;
            _roleSVC = roleSVC;
            _userRolesSVC = userRolesSVC;
            _roleAccessSVC = roleAccessSVC;
            _accessLinkSVC = accessLinkSVC;
            //_httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            _mapper = mapper;
            _emailSender = emailSender;
            _emailConfiguration = emailConfiguration.Value;
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Register(UserRegisterDto data)
        {
            User user = await _userSVC.FindOneAsync(x => x.Username.ToLower().Equals(data.UserName.ToLower()));

            if (user == null)
            {
                user = new User();
                user.Username = data.UserName;
                user.FirstName = data.FirstName;
                user.LastName = data.LastName;
                user.Password = data.Password.Encrypt();
                //user.Token = randomTokenString();
                //user.Active = false;
                var res = await _userSVC.AddUserAsync(user);
                //sendVerifyAccountUrl(data.UserName, data.Password, user.ResetToken);

                response.Success = true;
                response.Message = "لیک فعال سازی حساب کاربری شما به ایمل شما ارسال گرددید";
            }
            else
            {
                response.Success = false;
                response.Message = "حساب کاربری واردشده در سامانه موجود می باشد";
            }
            ViewData["response"] = response;
            return View();
        }


        [HttpGet()]
        public IActionResult VerifyAccount(string token)
        {
            if (!string.IsNullOrEmpty(token))
            {
                return RedirectToAction("login");
            }
            return View("Error");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Login(SaveLoginDto data)
        {
            User user = await _userSVC.FindOneAsync(x => x.Username.ToLower().Equals(data.UserName.ToLower()));
            if (user != null)
            {
                //var d = data.Password.Encrypt();
                if (data.Password.ToLower().Equals(user.Password.Decrypt().ToLower()))
                {
                    response.Success = true;
                    var token = await CreateToken(user);
                    //response.Data = token;

                    HttpContext.Session.SetString("JWToken", token);

                    var userAccessUrls = (from u in await _userSVC.GetManyUsersAsync(x => x.Id == user.Id)
                                          join ur in await _userRolesSVC.GetAllUserRolesAsync() on u.Id equals ur.UserId
                                          join r in await _roleSVC.GetAllRolesAsync() on ur.RoleId equals r.Id
                                          join ra in await _roleAccessSVC.GetAllRoleAccessAsync() on r.Id equals ra.RoleId
                                          join al in await _accessLinkSVC.GetAllAccessLinksAsync() on ra.AccessLinkId equals al.Id
                                          where u.Id == user.Id
                                          select new AccessUrlViewModel
                                          {
                                              Link = $"/{al.Controller}/{al.Action}"
                                          }).ToList();

                    HttpContext.Session.SetComplexData("UserAccessUrls", userAccessUrls);
                    //HttpContext.Request.Headers.Add("Authorization", $"Bearer {response.Token}");
                    //_httpContextAccessor.HttpContext.Response.Cookies.Append("access_token", response.Token, new CookieOptions { HttpOnly = true, Secure = true });
                    //return new JsonResult(response);

                    return RedirectToAction("Index", "Home", new { area = "" });
                }
                else
                {
                    response.Success = false;
                    response.Message = "نام کاربری یا کلمه عبور اشتباه می باشد";
                }
            }
            else
            {
                response.Success = false;
                response.Message = "کاربری با مشخصات وارد شده یافت نشد";
            }
            //return new JsonResult(response);

            ViewData["response"] = response;
            return View();
        }

        //send generated token to email for reset password
        [HttpPost]
        public async Task<JsonResult> CkeckEmailValidity(string email)
        {
            var isValid = true;
            if (!string.IsNullOrEmpty(email))
            {
                var user = await _userSVC.FindOneAsync(x => x.Username.ToLower().Equals(email.ToLower()));
                if (user != null)
                {
                    user.Token = randomTokenString();
                    user.TokenExpireTime = DateTime.UtcNow.AddDays(1);
                    var updatedUser = await _userSVC.EditUserAsync(user);

                    var targetUrl = "";
                    targetUrl = $"{BaseUrl}/Account/ResetPassword?token={user.Token}";
                    var content = $@"<p>کاربر محترم به منظور بازنشانی کلمه عبور خود روی لینک زیر کلیک نماید. مدت اعتبار این لینک 24ساعت می باشد</p>
                             <br/><p><a href=""{targetUrl}"">{targetUrl}</a></p>";

                    var emailMessage = new Message(new List<string> { email }, "فراموشی کلمه عبور", content);
                    await _emailSender.SendEmailAsync(emailMessage);
                    response.Success = true;
                    response.Message = "کاربر گرامی جهت ادامه تغییر رمز عبور فعلی خود روی لینک ارسال شده به ایمیل خود کلیک نمایید";
                }
                else
                    isValid = false;
            }

            if (!isValid)
            {
                response.Success = false;
                response.Message = "کاربری با ایمیل مورد نظر یافت نشد";
            }
            return Json(response);
        }


        [HttpGet]
        public async Task<IActionResult> ResetPassword(string token = null)
        {
            ResetPasswordDto restModel = new ResetPasswordDto();
            if (!string.IsNullOrEmpty(token))
            {
                var user = await _userSVC.FindOneAsync(x => x.Token == token && x.TokenExpireTime > DateTime.UtcNow);
                if (user == null)
                    return RedirectToAction("Login");
                restModel.Token = user.Token;
                restModel.UserName = user.Username;
            }
            ViewData["response"] = response;
            return View(restModel);
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordDto data)
        {
            ResetPasswordDto restModel = new ResetPasswordDto();
            if (!string.IsNullOrEmpty(data?.Token))
            {
                var user = await _userSVC.FindOneAsync(x => x.Token == data.Token
                   && x.TokenExpireTime > DateTime.UtcNow && x.Username.Equals(data.UserName));
                if (user != null)
                {
                    if (!string.IsNullOrEmpty(data?.Password)
                    && !string.IsNullOrEmpty(data?.ConfirmPassword)
                    && data.Password.ToLower().Trim().Equals(data.ConfirmPassword.ToLower().Trim()))
                    {
                        user.Password = data.Password.Encrypt();
                        user.Token = null;
                        user.TokenExpireTime = null;
                        var updatUser = await _userSVC.EditUserAsync(user);
                        response.Success = true;
                        response.Message = "هم اکنون میتوانید با کلمه عبور جدید لاگین نمایید";
                    }
                    else
                    {
                        response.Success = false;
                        response.Message = "عدم تطابق کلمه عبور و تکرار آن";
                    }
                }
                else
                {
                    response.Success = false;
                    response.Message = "کاربر با اطلاعات وارد شده یافت نشد لطفا از صفحه لاگین روی لینک فراموشی کلمه عبور کلیک نمایید تا توکن جدید به ایمیل شما ارسال گردد";
                }
            }
            else
            {
                response.Success = false;
                response.Message = "کاربرگرامی توکن نامعتبر می باشد لطفا از صفحه لاگین روی لینک فراموشی کلمه عبور کلیک نمایید تا توکن جدید به ایمیل شما ارسال گردد";
            }
            ViewData["response"] = response;
            restModel.Token = data?.Token;
            restModel.UserName = data?.UserName;
            return View(restModel);
        }


        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordDto data)
        {
            ChangePasswordDto restModel = new ChangePasswordDto();

            var user = await _userSVC.FindOneAsync(x =>
                x.Username.ToLower().Equals(data.UserName.ToLower())
                //&& x.Password.Decrypt().Equals(data.Password.Trim())
                );
            if (user != null && user.Password.Decrypt().Equals(data.Password.Trim()))
            {
                user.Password = data.NewPassword.Encrypt();
                var updatUser = await _userSVC.EditUserAsync(user);
                response.Success = true;
                response.Message = "هم اکنون میتوانید با کلمه عبور جدید لاگین نمایید";
            }
            else
            {
                response.Success = false;
                response.Message = "کاربری با مشخصات وارده یافت نشد";
            }
            ViewData["response"] = response;        
            return View(restModel);
        }



        private async Task<string> CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Username),
                new Claim(ClaimTypes.Name, user.FirstName+" "+user.LastName),
                //new Claim("FullName", user.FirstName+" "+user.LastName),
            };
            //########################
            var userRoles = await _userRolesSVC.GetManyUserRolesAsync(r => r.UserId == user.Id);
            var userRoleIds = userRoles.Select(s => s.RoleId);
            var urIds = string.Join(',', userRoleIds);
            claims.Add(new Claim(ClaimTypes.Role, urIds));

            //var adminRole = userRoles.FirstOrDefault(x => x.RoleId == (decimal)EnumRole.ADMIN);
            //if (adminRole != null)
            //{
            //    claims.Add(new Claim(ClaimTypes.Role, adminRole.RoleId.ToString()));
            //}
            //else
            //{
            //    userRoles.ToList().ForEach(ur =>
            //    {
            //        claims.Add(new Claim(ClaimTypes.Role, ur.RoleId.ToString()));
            //    });

            //    var roleAccess = await _roleAccessSVC.GetManyRoleAccessAsync(l => userRoleIds.Contains(l.RoleId));
            //    var accessLinkIds = roleAccess.Select(ss => ss.AccessLinkId);
            //    var accessLinks = await _accessLinkSVC.GetManyAccessLinksAsync(al => accessLinkIds.Contains(al.Id));
            //    accessLinks = accessLinks.Distinct();

            //    //List<Claim> claimLinks = new List<Claim>();
            //    //roleAccess.ToList().ForEach(al => {
            //    //    claimLinks.Add(new Claim(ClaimTypes.Uri ,$"/{al.AccessLink.}/{}");
            //    //});
            //}


            //########################
            SymmetricSecurityKey key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration.GetSection("Jwt:Secret").Value)
            );

            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Issuer = _configuration.GetSection("Jwt:Issuer").Value,
                Audience = _configuration.GetSection("Jwt:Audience").Value,
                NotBefore = new DateTimeOffset(DateTime.Now).DateTime,
                Expires = DateTime.Now.AddMinutes(30),
                SigningCredentials = creds
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        private string randomTokenString()
        {
            using (var rngCryptoServiceProvider = new RNGCryptoServiceProvider())
            {
                var randomBytes = new byte[40];
                rngCryptoServiceProvider.GetBytes(randomBytes);
                // convert random bytes to hex string
                return BitConverter.ToString(randomBytes).Replace("-", "");
            }
        }


        private void sendVerifyAccountUrl(string toEmail, string plainTextPass, string token)
        {
            var verifyUrl = "";
            verifyUrl = $"{BaseUrl}/Account/VerifyAccount?token={token}";

            string body = "<br/><br/>کاربر گرامی جهت فعال سازی حساب کاربری خود روی لینک زیر کلیک نمایید.با تشکر <strong>" + plainTextPass + "</strong>!";
            body += "<a href='" + verifyUrl + "'>" + verifyUrl + "</a>";

            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(_emailConfiguration.From);
                    mail.To.Add(toEmail);
                    mail.Subject = "فعال سازی حساب کاربری!";
                    mail.Body = body;
                    mail.IsBodyHtml = true;
                    //mail.Attachments.Add(new Attachment("C:\\file.zip"));

                    //using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    using (SmtpClient smtp = new SmtpClient(_emailConfiguration.SmtpServer, 587))
                    {
                        smtp.UseDefaultCredentials = false;
                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                        smtp.Credentials = new NetworkCredential(_emailConfiguration.UserName, _emailConfiguration.Password);
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                        smtp.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                //throw ex;
            }

        }
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }


    }
}