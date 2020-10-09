using Microsoft.AspNetCore.Mvc;
using SNBExfeedReader.Services;
using System.Threading.Tasks;

namespace FlowApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SNBController : ControllerBase
    {
        [HttpPost("rss/update")]
        [Consumes("application/rss+xml")]
        [Produces("application/rss+xml")]
        public rss SetRss([FromBody] rss snbrss)
        {
            return snbrss;
        }
        [HttpGet("rss/update")]
        [Produces("application/rss+xml")]
        public async Task<rss> Update()
        {
            var consumer = new SNBExfeedConsumer();
            return await consumer.ConsumeAsync();
        }
    }
}
