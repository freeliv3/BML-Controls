namespace BML_Controls_Backend.Domain.Models
{
    public class Company
    {
        public int Id { get; set; } 
        public string Name { get; set; } 
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
