using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Cryptography;
using System.Security.Permissions;

namespace migration_test_deprecated.Controllers;

[ApiController]
[Route("[controller]")]
public class DeprecatedController : ControllerBase
{
    [HttpGet("fetch")]
    public async Task<IActionResult> FetchData()
    {
        // WebClient is deprecated
        using (var client = new HttpClient())
        {
    try {
        string data = await client.GetStringAsync("https://api.github.com");
        return Ok(data);
    } catch {
        return StatusCode(500, "Failed to download");
    }
        }
    }

    [HttpGet("random")]
    public IActionResult GetRandomBytes()
    {
        // RNGCryptoServiceProvider is deprecated
        using (var rng = RandomNumberGenerator.Create())
        {
    byte[] bytes = new byte[16];
    rng.GetBytes(bytes);
    return Ok(Convert.ToBase64String(bytes));
        }
    }
}
