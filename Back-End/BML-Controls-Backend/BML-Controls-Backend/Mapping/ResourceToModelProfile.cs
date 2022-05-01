using AutoMapper;
using BML_Controls_Backend.Domain.Models;
using BML_Controls_Backend.Resources;

namespace BML_Controls_Backend.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveUserResource, User>();
            CreateMap<SaveCompanyResource, Company>();
            CreateMap<SaveAdminResource, Admin>();
        }
    }
}
