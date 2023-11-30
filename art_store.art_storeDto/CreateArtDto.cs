using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace art_store.art_storeDto
{
    public class CreateArtDto
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public bool Status { get; set; }
        public DateTime Year { get; set; }
        public float Price { get; set; }
        public int? OrderId { get; set; }
    }
}
