using art_store.Entities;

public class Order
{
    public int Id { get; set; }
    public int? UserId { get; set; }
    public string DeliveryAddress { get; set; }
    public DateTime DeliveryData { get; set; }
    public List<Art>? Arts { get; set; }

    public Driver? Driver { get; set; }

    public int? DriverId { get; set; }

    public User? User { get; set; }




    //public List<Driver> Drivers { get; set; }

    //public List<User> Users { get; set; }
}