using AutoMapper;
using Calcis.Modules.Employee.Application.Commands.DTO;
using Calcis.Modules.Employee.Infrastructure.Database.ReadDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcis.Modules.Employee.Infrastructure
{
    internal class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserProjectionModel, User>(MemberList.Source)
                // Mapowanie wszystkich pól jawnie
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username))
                .ForMember(dest => dest.Enabled, opt => opt.MapFrom(src => src.Enabled))
                .ForMember(dest => dest.Totp, opt => opt.MapFrom(src => src.Totp))
                .ForMember(dest => dest.EmailVerified, opt => opt.MapFrom(src => src.EmailVerified))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.State))
                .ForMember(dest => dest.NotBefore, opt => opt.MapFrom(src => src.NotBefore))
                // Ignorowanie ról (bo w User jest ICollection<UserRole>)
                .ForMember(dest => dest.Roles, opt => opt.Ignore())
                // Nie walidujemy źródłowej właściwości Roles
                .ForSourceMember(src => src.Roles, opt => opt.DoNotValidate());
        }
    }
}
