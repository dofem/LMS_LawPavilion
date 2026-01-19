using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using LIBRARY_MANAGEMENT_SYSTEM.DTOs;
using LIBRARY_MANAGEMENT_SYSTEM.Enums;
using LIBRARY_MANAGEMENT_SYSTEM.Services.Implementation;
using LIBRARY_MANAGEMENT_SYSTEM.Services.Interface;
namespace LIBRARY_MANAGEMENT_SYSTEM.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

       
        [HttpGet("getbooks")]
        [Authorize(Roles = nameof(UserRole.Admin) + "," + nameof(UserRole.SeniorLibrarian) + "," + nameof(UserRole.JuniorLibrarian))]
        public IActionResult Get([FromQuery] string search = "",[FromQuery] int pageNumber = 1,[FromQuery] int pageSize = 10)
        {
            var resp = _bookService.GetBooks(search, pageNumber, pageSize);
            return Ok(resp);
        }

        
        [HttpPost("addbook")]
        [Authorize(Roles = nameof(UserRole.Admin) + "," + nameof(UserRole.SeniorLibrarian))]
        public IActionResult Create([FromBody] BookCreateDto dto)
            => Ok(_bookService.Create(dto));

       
        [HttpPut("{id}")]
        [Authorize(Roles = nameof(UserRole.Admin) + "," + nameof(UserRole.SeniorLibrarian))]
        public IActionResult Update(int id, [FromBody] BookUpdateDto dto)
            => Ok(_bookService.Update(id, dto));

      
        [HttpDelete("{id}")]
        [Authorize(Roles = nameof(UserRole.Admin))]
        public IActionResult Delete(int id)
            => Ok(_bookService.Delete(id));
    }

}
