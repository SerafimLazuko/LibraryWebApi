namespace Library.DAL.Models
{
    public class BookModel
    {
        public Guid BookId { get; set; }

        public string IBAN { get; set; }

        public string Name { get; set; }    

        public string Genre { get; set; }

        public string Description { get; set; }

        public string Author { get; set; }

        public List<RentModel> Rents { get; set; }

        public void EditBook(BookModel bookModel)
        {
            IBAN = bookModel.IBAN;
            Name = bookModel.Name;
            Genre = bookModel.Genre;
            Description = bookModel.Description;
            Author = bookModel.Author;
        }
    }
}
