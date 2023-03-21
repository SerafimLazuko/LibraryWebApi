namespace Library.BLL.DTO
{
    public class BookToEditDTO
    {
        public Guid BookId { get; set; }

        public string IBAN { get; set; }

        public string Name { get; set; }

        public string Genre { get; set; }

        public string Description { get; set; }

        public string Author { get; set; }
    }
}
