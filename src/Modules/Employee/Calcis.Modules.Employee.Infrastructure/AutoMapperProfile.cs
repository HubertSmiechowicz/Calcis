using AutoMapper;
using Calcis.Modules.Employee.Application.DTO;
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
            CreateMap<UserProjectionModel, User>()
                .ForMember(p => p.Roles, o => o.Ignore());
        }
    }
}
