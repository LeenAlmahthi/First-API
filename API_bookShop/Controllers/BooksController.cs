using Microsoft.AspNetCore.Mvc;

[ApiController]  //tells ASP.NET Core that this class handles Web API requests and should use API-specific behavior.
[Route(["books"]);

public class BooksController : ControllerBase
{
    [HttpGet]
    public IActionResult GetBooks()
    {
        show_book();
        return Ok();
    }
} 