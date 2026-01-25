using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyApp.Controllers.Test
{
    [Route("api/test")]
    [ApiController]
    public class TestController : ControllerBase
    {
        //テスト用
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("TestOK");
        }
    }
}
