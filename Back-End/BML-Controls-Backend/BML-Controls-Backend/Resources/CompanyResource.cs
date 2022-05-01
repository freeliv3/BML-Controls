namespace BML_Controls_Backend.Resources
{
    public class CompanyResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public UserResource User { get; set; }
    }
}
