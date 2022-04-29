using BML_Controls_Backend.Domain.Models;

namespace BML_Controls_Backend.Domain.Services.Comunications
{
    public class AdminResponse : BaseResponse<Admin>
    {
        public AdminResponse(Admin resource) : base(resource)
        {
        }

        public AdminResponse(string message) : base(message)
        {
        }
    }
}
