using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Controller]
    [Route("api")]
    public class ApiController : ApiControllerBase
    {
        [HttpGet]
        public string Get()
            => "{ Api: Ok; Mensagem: Que a força esteja com você! }";
    }
}
