using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


[ApiController]  //tells ASP.NET Core that this class handles Web API requests and should use API-specific behavior.
[Route("api/[controller]")]

//BooksController

public class BooksControllers : ControllerBase
{
    data_context data; // the obj of the class 
    public BooksControllers(data_context context)
    {
        data = context;
    }
    [HttpGet]
    public IActionResult GetBooks()
    {
        return Ok(data.books.ToList());

    }
    [HttpGet("{id}")]
    public IActionResult Getbook(int id)
    {
        Book b = data.books.Find(id);
        if (b == null)
            return NotFound();
        return Ok(b);
    }
    [HttpPost]
    public IActionResult Postbook(Book book)
    {
        if (book == null)
            return NotFound();
        data.books.Add(book);
        data.SaveChanges();
        return Ok(book);
    }
    [HttpPut("{id}")]
    public IActionResult putbook(int id, Book book)
    {
        Book tmp = data.books.Find(id);
        if (tmp == null)
            return NotFound();
        tmp.Title = book.Title;
        tmp.Author = book.Author;
        tmp.PublishedYear = book.PublishedYear;
        tmp.CategoryId = book.CategoryId;
        data.SaveChanges();
        return Ok(tmp);
    }
    [HttpDelete("{id}")]
    public IActionResult deletebook(int id) 
    {
        Book tmp = data.books.Find(id);
        if (tmp == null)
            return NotFound();
        data.books.Remove(tmp);
        data.SaveChanges();
        return Ok(tmp);
    }

} 