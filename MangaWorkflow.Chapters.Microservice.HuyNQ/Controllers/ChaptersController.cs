using MangaWorkflow.BusinessObject.Shared.Models.HuyNQ;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MangaWorkflow.Chapters.Microservice.HuyNQ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChaptersController : ControllerBase
    {
        private List<ChapterHuyNq> _chapters = [];

        private readonly IBus _bus;

        private readonly ILogger _logger;

        public ChaptersController(IBus bus, ILogger<ChaptersController> logger)
        {
            _bus = bus;
            _logger = logger;

            _chapters =
            [
                new()
                {
                    HuynqId = 1,
                    ChapterMetaHuynqId = 1,
                    Title = "Son Goku",
                    ChapterNumber = 3,
                    ChapterMetaHuynq = new() {
                        HuynqId = 1,
                        Code = "101",
                        Description = "Good"
                    }
                },
                new()
                {
                    HuynqId = 2,
                    ChapterMetaHuynqId = 1,
                    Title = "Luffy",
                    ChapterNumber = 4,
                }
            ];
        }

        // GET: api/<ChaptersController>
        [HttpGet]
        public IEnumerable<ChapterHuyNq> Get()
        {
            return _chapters;
        }

        // GET api/<ChaptersController>/5
        [HttpGet("{id}")]
        public ChapterHuyNq Get(int id)
        {
            return _chapters.Find(c => c.HuynqId == id) ?? new();
        }

        // POST api/<ChaptersController>
        [HttpPost]
        public async Task Post([FromBody] ChapterHuyNq value)
        {
            Uri uri = new("rabbitmq://localhost/chapterQueue");
            var endPoint = await _bus.GetSendEndpoint(uri);
            await endPoint.Send(value);

            var msg = string.Format("{0}: PUBLISH the event to chapterQueue queue on RabbitMQ: {1}", DateTime.Now, JsonSerializer.Serialize(value));
            _logger.LogInformation(msg);

            Serilog.Log.Information(msg);

            // Console.WriteLine("Submit order: " + JsonSerializer.Serialize(value));
        }

        // PUT api/<ChaptersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ChaptersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
