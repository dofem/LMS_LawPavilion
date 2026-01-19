using LIBRARY_MANAGEMENT_SYSTEM.DTOs;
using LIBRARY_MANAGEMENT_SYSTEM.Utilities;

namespace LIBRARY_MANAGEMENT_SYSTEM.Services.Interface
{
    public interface IBookService
    {
        ApiResponse Create(BookCreateDto dto);
        ApiResponse<object> Delete(int id);
        ApiResponse<PagedResultDto<BookResponseDto>> GetBooks(string search, int pageNumber, int pageSize);
        ApiResponse<object> Update(int id, BookUpdateDto dto);
    }
}