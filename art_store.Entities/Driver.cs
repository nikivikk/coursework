namespace art_store.Entities
{
    public class Driver
    {
        public int Id { get; set; }
        public string Fio { get; set; }

        public string Email { get; set; }    
        public string Password { get; set; }

        public int OrderId { get; set; }

    }
}
