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
        [Required]
        [StringLength(100, MinimumLength = 10)]
        public string Fio { get; set; }
        [Required]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}")]
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$")]
        public string Password { get; set; }
        public string Role { get; set; }
        [Required]
        [StringLength(3, MinimumLength = 1)]

        public int Age { get; set; }
    }
}
