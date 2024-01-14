using Microsoft.AspNetCore.Mvc;

namespace MicroIMS.Api.Controllers;

public class ErrorsController : ControllerBase
{
    [Route("/error")]
    [HttpGet]
    public IActionResult Error()
    {
        return Problem();
    }
}