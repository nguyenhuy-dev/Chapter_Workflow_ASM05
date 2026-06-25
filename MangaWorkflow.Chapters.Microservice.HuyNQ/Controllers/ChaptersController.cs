using MangaWorkflow.BusinessObject.Shared.Models.HuyNQ;
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

        public ChaptersController()
        {
            _chapters =
            [
                new()
                {
                    HuynqId = 1,
                    ChapterMetaHuynqId = 1,
                    Title = "Son Goku",
                    ChapterNumber = 3,

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
        public void Post([FromBody] ChapterHuyNq value)
        {
            Console.WriteLine("Submit order: " + JsonSerializer.Serialize(value));
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
