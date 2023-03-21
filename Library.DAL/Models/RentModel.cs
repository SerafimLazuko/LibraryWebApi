namespace Library.DAL.Models
{
    public class RentModel
    {
        public Guid RentId { get; set; }

        public Guid UserId { get; set; }

        public Guid BookId { get; set; }

        public BookModel BookModel { get; set; }

        public DateTime RentStarted { get; set; }

        public DateTime RentClosed { get; set; }
    }
}
