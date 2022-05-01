using System.ComponentModel.DataAnnotations;

namespace BML_Controls_Backend.Resources
{
    public class SaveAdminResource
    {
        [Required]
        [MaxLength(40)]
        public string Name { get; set; }
    }
}
