using art_store.Entities;

public class Order
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string DeliveryAddress { get; set; }
    public DateTime DeliveryData { get; set; }
    // Здесь не нужны айдишки артов, достаточно просто объектов, посмотри про связь один ко многи в EF
    public List<Art>? Arts { get; set; }
}