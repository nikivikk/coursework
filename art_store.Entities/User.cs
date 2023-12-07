using Microsoft.AspNetCore.Identity;


namespace art_store.Entities
{
    public class User : IdentityUser<int>
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public List<Order>? Orders { get; set; }

    }
}

