using API.Models;
using API.ViewVM;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly aloooContext _context;
        private readonly IMapper _mapper;
        public AuthController(IConfiguration configuration, aloooContext context, IMapper mapper)
        {
            _configuration = configuration;
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Login(Account model)
        {
            List<Account> accounts = _context.Accounts.ToList();
            foreach (var account in accounts)
            {
                if (account.Username == model.Username && account.Password == model.Password)
                {
                    return Ok(account);
                }
            }
            return BadRequest();

        }
    }
}
