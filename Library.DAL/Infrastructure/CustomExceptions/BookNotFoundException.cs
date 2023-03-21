namespace Library.DAL.Infrastructure.CustomExceptions
{
    public class BookNotFoundException : Exception
    {
        public BookNotFoundException()
        {
        }

        public BookNotFoundException(string message)
        {
        }

        public BookNotFoundException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
