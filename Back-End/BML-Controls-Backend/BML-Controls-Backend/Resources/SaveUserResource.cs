using System.ComponentModel.DataAnnotations;

namespace BML_Controls_Backend.Resources
{
    public class SaveUserResource
    {
        [Required]
        [MaxLength(40)]
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
    }
}
