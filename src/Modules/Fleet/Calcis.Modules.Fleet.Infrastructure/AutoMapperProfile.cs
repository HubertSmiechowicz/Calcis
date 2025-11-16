using AutoMapper;
using Calcis.Modules.Fleet.Application.Commands;
using Calcis.Shared.Events.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcis.Modules.Fleet.Infrastructure
{
    internal class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreatedUserDriverCommand, Database.WriteDAO.Driver>(MemberList.Source)
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.id))
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.firstName))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.lastName))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.email))

            // Pozostałe pola w encji, których nie ma w Command, ustawiamy na default / ignorujemy
            .ForMember(dest => dest.DrivingLicenseNumber, opt => opt.Ignore())
            .ForMember(dest => dest.DrivingLicenseExpiryDate, opt => opt.Ignore())
            .ForMember(dest => dest.Is95Code, opt => opt.Ignore())
            .ForMember(dest => dest.TachographCardNumber, opt => opt.Ignore())
            .ForMember(dest => dest.IsMedicalCertificateValid, opt => opt.Ignore())
            .ForMember(dest => dest.MedicalCertificateExpiryDate, opt => opt.Ignore())
            .ForMember(dest => dest.IsPsychologicalExamValid, opt => opt.Ignore())
            .ForMember(dest => dest.PsychologicalExamExpiryDate, opt => opt.Ignore())
            .ForMember(dest => dest.IdentityCardNumber, opt => opt.Ignore())
            .ForMember(dest => dest.IdentityCardExpiryDate, opt => opt.Ignore())
            .ForMember(dest => dest.PassportNumber, opt => opt.Ignore())
            .ForMember(dest => dest.PassportExpiryDate, opt => opt.Ignore())
            .ForMember(dest => dest.CertificateNoCriminalRecordNumber, opt => opt.Ignore())
            .ForMember(dest => dest.AdrNumber, opt => opt.Ignore())
            .ForMember(dest => dest.AdrExpiryDate, opt => opt.Ignore());

            CreateMap<CreateDriverReadModelCommand, Database.ReadDAO.Driver>(MemberList.Source)
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.id))
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.firstName))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.lastName))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.email))
            // Pozostałe pola w encji, których nie ma w Command, ustawiamy na default / ignorujemy
            .ForMember(dest => dest.DrivingLicenseNumber, opt => opt.Ignore())
            .ForMember(dest => dest.DrivingLicenseExpiryDate, opt => opt.Ignore())
            .ForMember(dest => dest.Is95Code, opt => opt.Ignore())
            .ForMember(dest => dest.TachographCardNumber, opt => opt.Ignore())
            .ForMember(dest => dest.IsMedicalCertificateValid, opt => opt.Ignore())
            .ForMember(dest => dest.MedicalCertificateExpiryDate, opt => opt.Ignore())
            .ForMember(dest => dest.IsPsychologicalExamValid, opt => opt.Ignore())
            .ForMember(dest => dest.PsychologicalExamExpiryDate, opt => opt.Ignore())
            .ForMember(dest => dest.IdentityCardNumber, opt => opt.Ignore())
            .ForMember(dest => dest.IdentityCardExpiryDate, opt => opt.Ignore())
            .ForMember(dest => dest.PassportNumber, opt => opt.Ignore())
            .ForMember(dest => dest.PassportExpiryDate, opt => opt.Ignore())
            .ForMember(dest => dest.CertificateNoCriminalRecordNumber, opt => opt.Ignore())
            .ForMember(dest => dest.AdrNumber, opt => opt.Ignore())
            .ForMember(dest => dest.AdrExpiryDate, opt => opt.Ignore());
        }
    }
}
