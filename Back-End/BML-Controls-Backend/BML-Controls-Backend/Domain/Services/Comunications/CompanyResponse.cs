using BML_Controls_Backend.Domain.Models;

namespace BML_Controls_Backend.Domain.Services.Comunications
{
    public class CompanyResponse : BaseResponse<Company>
    {
        public CompanyResponse(Company resource) : base(resource)
        {
        }

        public CompanyResponse(string message) : base(message)
        {
        }
    }
}
