using BML_Controls_Backend.Domain.Models;

namespace BML_Controls_Backend.Domain.Services.Comunications
{
    public class UserResponse : BaseResponse<User>
    {
        public UserResponse(User resource) : base(resource)
        {
        }

        public UserResponse(string message) : base(message)
        {

        }
    }
}
