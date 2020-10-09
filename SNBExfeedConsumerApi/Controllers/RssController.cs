using Microsoft.AspNetCore.Mvc;
using SNBExfeedReader.Services;
using System.Threading.Tasks;

namespace SNBExfeedApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class RssController : ControllerBase
    {
        [HttpPost("xml")]
        [Consumes("application/rss+xml")]
        [Produces("application/rss+xml")]
        public async Task<rss> PostAsXml([FromBody] rss snbrss)
        {
            return await Task.FromResult(snbrss);
        }
        [HttpPost("json")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<rss> PostAsJson([FromBody] rss snbrss)
        {
            return await Task.FromResult(snbrss);
        }
        [HttpGet("xml")]
        [Produces("application/rss+xml")]
        public async Task<rss> GetAsXml()
        {
            var consumer = new SNBExfeedConsumer();
            return await consumer.ConsumeAsync();
        }
        [HttpGet("json")]
        [Produces("application/json")]
        public async Task<rss> GetAsJson()
        {
            var consumer = new SNBExfeedConsumer();
            return await consumer.ConsumeAsync();
        }
    }
}
