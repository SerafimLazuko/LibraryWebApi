namespace Library.User.DAL.Models
{
    public class UserModel
    {
        public Guid UserId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Password { get; set; }

        public string Login { get; set; }
    }
}
