namespace LIBRARY_MANAGEMENT_SYSTEM.DTOs
{
    public class BookCreateDto
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public DateTime PublishedDate { get; set; }
    }

    public class BookUpdateDto : BookCreateDto { }

    public class BookResponseDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
    }

}
