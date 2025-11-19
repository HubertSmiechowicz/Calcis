using AutoMapper;
using Calcis.Modules.Maintenance.Application.Commands;
using Calcis.Modules.Maintenance.Application.Repositories;
using Calcis.Modules.Maintenance.Infrastructure.Database;
using Calcis.Modules.Maintenance.Infrastructure.Database.ReadDAO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcis.Modules.Maintenance.Infrastructure.Repositories
{
    internal class MaintenanceReadModelWriter : IMaintenanceReadModelWriter
    {
        private MaintenanceReadDbContext _dbContext;
        private IMapper _mapper;

        public MaintenanceReadModelWriter(MaintenanceReadDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task CreateDriverAsync(CreateMechanicReadModelCommand model, CancellationToken cancellationToken)
        {
            var mechanic = _mapper.Map<Mechanic>(model);
            _dbContext.Mechanics.Add(mechanic);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
