namespace Library.BLL.DTO
{
    public class UserLoginedDTO
    {
        public Guid UserId { get; set; }

        public string Login { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Token { get; set; }
    }
}
