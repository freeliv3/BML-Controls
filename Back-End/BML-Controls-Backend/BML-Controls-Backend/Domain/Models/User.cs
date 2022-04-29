

namespace BML_Controls_Backend.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public string Region { get; set; }
        public string City { get; set; }

        public IList<Company> Companies { get; set; } = new List<Company>();

    }
}
