using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace art_store.art_storeDto
{
    public class UserDto : CreateUserDto
    {
        public int Id { get; set; }

    }
}