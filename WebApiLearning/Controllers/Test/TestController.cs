using Microsoft.AspNetCore.Mvc;
using MyApp.Services.Test;
using MyApp.Models.Test;

namespace MyApp.Controllers.Test
{
    [Route("api/test")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ITestService _service;

        public TestController(ITestService service)
        {
            _service = service;
        }

        [HttpGet("{id?}")]
        public IActionResult Get(int? id)
        {
            var entity = _service.Get(id);
            if (entity == null) return NotFound();
            return Ok(entity);
        }


        [HttpPost]
        public IActionResult Post(TestCreateDto dto)
        {
            _service.Create(dto);
            return Ok();
        }

        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return Ok();
        }


        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]TestUpdateDto dto)
        {
            _service.Update(id, dto);
            return Ok();
        }
    }
}
