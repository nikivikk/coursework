namespace art_store.Entities
{
    public class Art
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Author {  get; set; }

        public bool Status {  get; set; }

        public string Driver {  get; set; }

        public DateTime Year { get; set; }

        public float Price { get; set; }
    }
}