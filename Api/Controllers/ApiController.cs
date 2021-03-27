using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Controller]
    [Route("api")]
    public class ApiController : ControllerBase
    {
        [HttpGet]
        public string Get()
            => "{ Api: Ok; Mensagem: Que a força esteja com você! }";
    }
}
