/* using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace MyBGList.Controllers
{
    public class ErrorController : Controller
    {
        [Route("/error")]
        [HttpGet]
        public IActionResult Error()
        {
            return Problem();
        }

        [Route("/error/test")]
        [HttpGet]
        public IActionResult Test()
        {
            throw new Exception("test");
        }
    }
}
Exemplo de como substituir as minimals APIS de erro lá do Program.cs
*/