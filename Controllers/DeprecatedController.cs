using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace migration_test_deprecated.Controllers;

[ApiController]
[Route("[controller]")]
public class DeprecatedController : ControllerBase
{
    private static readonly HttpClient _httpClient = new HttpClient();

    [HttpGet("fetch")]
    public async Task<IActionResult> FetchData()
    {
        // Replaced WebClient with HttpClient and asynchronous API
        try
        {
            // GitHub API requires a User-Agent header
            _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("migration-test-deprecated");
            string data = await _httpClient.GetStringAsync("https://api.github.com");
            return Ok(data);
        }
        catch
        {
            return StatusCode(500, "Failed to download");
        }
    }

    [HttpGet("random")]
    public IActionResult GetRandomBytes()
    {
        // Replaced RNGCryptoServiceProvider with RandomNumberGenerator
        byte[] bytes = new byte[16];
        RandomNumberGenerator.Fill(bytes);
        return Ok(Convert.ToBase64String(bytes));
    }
}
