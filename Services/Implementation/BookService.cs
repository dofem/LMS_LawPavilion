using LIBRARY_MANAGEMENT_SYSTEM.Data;
using LIBRARY_MANAGEMENT_SYSTEM.DTOs;
using LIBRARY_MANAGEMENT_SYSTEM.Entities;
using LIBRARY_MANAGEMENT_SYSTEM.Services.Interface;
using LIBRARY_MANAGEMENT_SYSTEM.Utilities;

namespace LIBRARY_MANAGEMENT_SYSTEM.Services.Implementation
{
    public class BookService : IBookService
    {
        private readonly AppDbContext _context;

        public BookService(AppDbContext context)
        {
            _context = context;
        }

        public ApiResponse<PagedResultDto<BookResponseDto>> GetBooks(string search, int pageNumber, int pageSize)
        {
            var query = _context.Books.AsQueryable();
            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(b =>
                    b.Title.Contains(search) ||
                    b.Author.Contains(search));
            }
            var totalRecords = query.Count();
            var books = query
                .OrderBy(b => b.Title)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(b => new BookResponseDto
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author
                })
                .ToList();
            var pagedResult =  new PagedResultDto<BookResponseDto>
            {
                Items = books,
                TotalRecords = totalRecords,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalPages = (int)Math.Ceiling(totalRecords / (double)pageSize)
            };
            return ApiResponse<PagedResultDto<BookResponseDto>>.Success(pagedResult, ApiResponseMessages.BookRetrieved);
        }
        public ApiResponse Create(BookCreateDto dto)
        {
            var book = new Book
            {
                Title = dto.Title,
                Author = dto.Author,
                ISBN = dto.ISBN,
                PublishedDate = dto.PublishedDate
            };

            _context.Books.Add(book);
            _context.SaveChanges();
            return ApiResponse<object>.Success(ApiResponseMessages.BookCreated);
        }
        public ApiResponse<object> Update(int id, BookUpdateDto dto)
        {
            var book = _context.Books.Find(id);        
            if(book is null)
            {
                return ApiResponse<object>.Fail(ApiResponseMessages.BookNotFound,ApiResponseMessages.NotFoundError);
            }
            book.Title = dto.Title;
            book.Author = dto.Author;
            book.ISBN = dto.ISBN;
            book.PublishedDate = dto.PublishedDate;

            _context.SaveChanges();

            return ApiResponse<object>.Success(ApiResponseMessages.BookUpdated);
        }
        public ApiResponse<object> Delete(int id)
        {
            var book = _context.Books.Find(id);
            if (book is null)
            {
                return ApiResponse<object>.Fail(ApiResponseMessages.BookNotFound, ApiResponseMessages.NotFoundError);
            }
            _context.Books.Remove(book);
            _context.SaveChanges();

            return ApiResponse<object>.Success(ApiResponseMessages.BookDeleted);
        }
    }

}
