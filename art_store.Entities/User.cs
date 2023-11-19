namespace art_store.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Fio { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }
        public List<Order>? Orders { get; set; }
    }
}

