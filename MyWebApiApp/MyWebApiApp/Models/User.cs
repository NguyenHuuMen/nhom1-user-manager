namespace MyWebApiApp.Models
{
    public class UserVM
    {
        public string userName { get; set; }
        public string userPassword { get; set; }
      

    }
    public class User : UserVM
    {
        public int id { get; set; }
    }
}
