using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Osoft.SiparisOnay.Core.Models;
using Osoft.SiparisOnay.Repository.IRepositories;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Osoft.SiparisOnay.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repo;
        public UserController(IUserRepository usersRepository)
        {
            _repo = usersRepository;
        }

        [HttpGet("{srk_no}")]
        public async Task<IActionResult> UserAll(int srk_no)
        {
            try
            {
                var modelData = await _repo.UserAll(srk_no);
                return Ok(new { statusCode = 200, rowCount = modelData.Count(), data = modelData });
            }
            catch (Exception ex)
            {
                return BadRequest(new { statusCode = 400, error = ex.Message });
            }
        }

        //[HttpGet("{srk_no}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //public async Task<IActionResult> UserAllTest(int srk_no)
        //{
        //    var modelData = await _repo.UserAll(srk_no);

        //    return Ok(modelData);

        //}


        [HttpGet("tokenclaims"), Authorize]
        public async Task<IActionResult> TokenClaims()
        {
            try
            {
                var userName = User?.Identity?.Name;
                return Ok(new { statusCode = 200, us_kod = userName });
            }
            catch (Exception ex)
            {
                return BadRequest(new { statusCode = 400, error = ex.Message });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> UsersLogin(Filter filter)
        {
            try
            {
                var users = await _repo.UserLogin(filter);
                bool isUserLoggedIn = users.Any();

                if (isUserLoggedIn)
                {
                    var user = users.FirstOrDefault();
                    user.cmpt_token = CreateJwt(user);
                    string degree = user.us_degree;

                    var response = new
                    {
                        access = true,
                        us_degree = degree,
                        cmpt_token = user.cmpt_token,
                        as_us_frmd_kod = user.us_frmd_kod
                    };

                    return Ok(response);
                }

                return Ok(new { access = false });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private static string CreateJwt(User user)
        {
            var secretkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("JwtSecurity")["Key"] ?? string.Empty));
            var credentials = new SigningCredentials(secretkey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.us_kod),
                new Claim("srk_no", user.srk_no.ToString()),
            };

            var token = new JwtSecurityToken(issuer: "domain.com", audience: "domain.com", claims: claims, expires: DateTime.Now.AddDays(1), signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}