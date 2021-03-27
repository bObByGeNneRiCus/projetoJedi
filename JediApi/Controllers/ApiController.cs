using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Controller]
    [Route("api")]
    public class ApiController
    {
        [HttpGet]
        public string Get()
            => "{ Api: Ok, Mensagen: Que a força esteja com você! }";
    }
}
