using AutoMapper;
using BML_Controls_Backend.Domain.Models;
using BML_Controls_Backend.Resources;

namespace BML_Controls_Backend.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<User, UserResource>();
            CreateMap<Company, CompanyResource>();
            CreateMap<Admin, AdminResource>();
        }
    }
}
