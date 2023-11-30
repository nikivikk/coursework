using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace art_store.art_storeDto
{
    public class CreateOrderDto
    {
        public int? UserId { get; set; }
        public string DeliveryAddress { get; set; }
        public DateTime DeliveryData { get; set; }
        public int? DriverId { get; set; } 

    }
}
