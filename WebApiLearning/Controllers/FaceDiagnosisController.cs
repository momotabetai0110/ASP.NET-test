using Microsoft.AspNetCore.Mvc;
using WebApiLearning.Services;

namespace MyApp.Namespace
{
    [Route("api/face-diagnosis")]
    [ApiController]
    public class FaceDiagnosisController : ControllerBase
    {
        private readonly IFaceDiagnosisService _service;
        public FaceDiagnosisController(IFaceDiagnosisService service)
    {
        _service = service;
    }
        //テスト用
        [HttpGet]
        public IActionResult Get()
        {
            var result = _service.Diagnose();
            return Ok(new[] { result });
        }
    }
}
