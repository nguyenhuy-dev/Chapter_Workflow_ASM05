using MangaWorkflow.BusinessObject.Shared.Models.HuyNQ;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MangaWorkflow.Chapters.Microservice.HuyNQ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChapterMetasController : ControllerBase
    {
        private List<ChapterMetaHuyNq> _metas = [];

        public ChapterMetasController()
        {
            _metas =
            [
                new() {
                    HuynqId = 1,
                    Code = "101",
                    Description = "Vuyp"
                }
            ];
        }

        // GET: api/<ChapterMetasController>
        [HttpGet]
        public IEnumerable<ChapterMetaHuyNq> Get()
        {
            return _metas;
        }

        // GET api/<ChapterMetasController>/5
        [HttpGet("{id}")]
        public ChapterMetaHuyNq Get(int id)
        {
            return _metas.Find(c => c.HuynqId == id) ?? new();
        }

        // POST api/<ChapterMetasController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ChapterMetasController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ChapterMetasController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
