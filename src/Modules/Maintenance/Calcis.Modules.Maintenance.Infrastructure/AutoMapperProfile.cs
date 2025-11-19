using AutoMapper;
using Calcis.Modules.Maintenance.Application.Commands;
using Calcis.Shared.Events.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcis.Modules.Maintenance.Infrastructure
{
    internal class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreatedUserMechanicCommand, Database.WriteDAO.Mechanic>(MemberList.Source)
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.id))
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.firstName))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.lastName))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.email))

            // Pozostałe pola w encji, których nie ma w Command, ustawiamy na default / ignorujemy
            .ForMember(dest => dest.IsFGaseCertiicate, opt => opt.Ignore())
            .ForMember(dest => dest.IsSepPermissions, opt => opt.Ignore())
            .ForMember(dest => dest.IsTdtPermissions, opt => opt.Ignore())
            .ForMember(dest => dest.IsWeldingPermissions, opt => opt.Ignore())
            .ForMember(dest => dest.IsTachographInstalationPermissions, opt => opt.Ignore())
            .ForMember(dest => dest.IsUdtPermissions, opt => opt.Ignore());

            CreateMap<CreateMechanicReadModelCommand, Database.ReadDAO.Mechanic>(MemberList.Source)
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.id))
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.firstName))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.lastName))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.email))

            // Pozostałe pola w encji, których nie ma w Command, ustawiamy na default / ignorujemy
            .ForMember(dest => dest.IsFGaseCertiicate, opt => opt.Ignore())
            .ForMember(dest => dest.IsSepPermissions, opt => opt.Ignore())
            .ForMember(dest => dest.IsTdtPermissions, opt => opt.Ignore())
            .ForMember(dest => dest.IsWeldingPermissions, opt => opt.Ignore())
            .ForMember(dest => dest.IsTachographInstalationPermissions, opt => opt.Ignore())
            .ForMember(dest => dest.IsUdtPermissions, opt => opt.Ignore());
        }
    }
}
