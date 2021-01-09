using DOAN52.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DOAN52.Controllers
{
    [Route("api/[controller]")]
    [Authorization]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _context;


        public AuthenticateController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration, ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            _configuration = configuration;
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAccount()
        {
            return await _context.User.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetAccounts(string id)
        {
            var acc = await _context.User.FindAsync(id);

            if (acc == null)
            {
                return NotFound();
            }

            return acc;
        }
        [HttpPost]
        public async Task<ActionResult<User>> PostAccounts(User accounts)
        {
            _context.User.Add(accounts);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AccountsExists(accounts.UserId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAccounts", new { id = accounts.UserId }, accounts);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccounts(string id, User accounts)
        {
            if (id != accounts.UserId)
            {
                return BadRequest();
            }

            _context.Entry(accounts).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteAccounts(string id)
        {
            var accounts = await _context.User.FindAsync(id);
            if (accounts == null)
            {
                return NotFound();
            }

            _context.User.Remove(accounts);
            await _context.SaveChangesAsync();

            return accounts;
        }

        private bool AccountsExists(string id)
        {
            return _context.User.Any(e => e.UserId == id);
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await userManager.FindByNameAsync(model.Username);
            if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );

                //return Ok(new
                //{
                //    token = new JwtSecurityTokenHandler().WriteToken(token),
                //    expiration = token.ValidTo
                //});
                return Ok(user);
            }
            return Unauthorized();
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var userExists = await userManager.FindByNameAsync(model.Username);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Tài khoản đã tồn tại!" });

            ApplicationUser user = new ApplicationUser()
            {
                Email = model.Email,
                FullName = model.FullName,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username,
            };
            var result = await userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Đăng kí không thành công! Vui lòng kiểm tra chi tiết và thử lại." });

            return Ok(new Response { Status = "Success", Message = "Đăng kí tài khoản thành công!" });
        }

        [HttpPost]
        [Route("register-admin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterModel model)
        {
            var userExists = await userManager.FindByNameAsync(model.Username);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Người dùng đã tồn tại !" });

            ApplicationUser user = new ApplicationUser()
            {
                Email = model.Email,
                FullName = model.FullName,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };
            var result = await userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Thất bại. Làm ơn xem lại !!!!" });

            if (!await roleManager.RoleExistsAsync(Role.Admin))
                await roleManager.CreateAsync(new IdentityRole(Role.Admin));
            if (!await roleManager.RoleExistsAsync(Role.User))
                await roleManager.CreateAsync(new IdentityRole(Role.User));

            if (await roleManager.RoleExistsAsync(Role.Admin))
            {
                await userManager.AddToRoleAsync(user, Role.Admin);
            }

            return Ok(new Response { Status = "Success", Message = "Đăng kí thành công!" });
        }

        [HttpGet]
        [Route("log")]
        public async Task<IActionResult> GetAccount([FromBody] RegisterModel model)
        {
            var getaccount = userManager.Users.ToList();
            return Ok(getaccount);
        }



        //[Route("delete-user")]
        //[HttpPost]
        //public IActionResult DeleteUser([FromBody] Dictionary<string, object> formData)
        //{
        //    string id = "";
        //    if (formData.Keys.Contains("id") && !string.IsNullOrEmpty(Convert.ToString(formData["id"]))) { id = Convert.ToString(formData["id"]); } Delete(id);
        //    return Ok();
        //}
    }

    internal class AuthorizationAttribute : Attribute
    {
       

    }
}