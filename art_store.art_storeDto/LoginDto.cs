using System.ComponentModel.DataAnnotations;

namespace art_store.art_storeDto
{
    public class LoginDto
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
