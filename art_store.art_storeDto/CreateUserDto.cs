using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace art_store.art_storeDto
{
    public class CreateUserDto
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        // public string Role { get; set; } Comment out for now, mapping can be added for Identity Role.
        public int Age { get; set; }
    }
}
