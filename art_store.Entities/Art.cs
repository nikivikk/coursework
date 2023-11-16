namespace art_store.Entities
{
    public class Art
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public bool Status { get; set; }
        public DateTime Year { get; set; }
        public float Price { get; set; }
        public int Id { get; set; }

        /// Сделал nullable, потому что арты могу существовать без ордера
        public int? OrderId { get; set; }
        public Order? Order { get; set; }
    }
}