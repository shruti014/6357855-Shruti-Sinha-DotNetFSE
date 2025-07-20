using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace exercise2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SecureController : ControllerBase
    {
        // This endpoint is protected and requires a valid JWT
        [Authorize]
        [HttpGet("data")]
        public IActionResult GetSecureData()
        {
            var username = User.Identity?.Name;
            return Ok($"Hello {username}, this is protected data.");
        }
    }
}