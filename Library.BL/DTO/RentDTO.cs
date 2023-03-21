namespace Library.BLL.DTO
{
    public class RentDTO
    {
        public Guid RentId { get; set; }

        public Guid BookId { get; set; }

        public Guid UserId { get; set; }

        public BookDTO BookDTO { get; set; }

        public DateTime RentStarted { get; set; }

        public DateTime RentClosed { get; set; }
    }
}
