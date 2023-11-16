using art_store.Entities;
using System.Text.Json.Serialization;

public class Order
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string DeliveryAddress { get; set; }
    public DateTime DeliveryData { get; set; }
    public List<int> ArtIds { get; set; }
    public List<Art> Arts { get; set; }
}