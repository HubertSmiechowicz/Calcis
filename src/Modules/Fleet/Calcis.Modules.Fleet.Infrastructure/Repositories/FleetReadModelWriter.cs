using AutoMapper;
using Calcis.Modules.Fleet.Application.Commands;
using Calcis.Modules.Fleet.Application.Repositories;
using Calcis.Modules.Fleet.Infrastructure.Database;
using Calcis.Modules.Fleet.Infrastructure.Database.ReadDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcis.Modules.Fleet.Infrastructure.Repositories
{
    internal class FleetReadModelWriter : IFleetReadModelWriter
    {
        private readonly FleetReadDbContext _dbContext;
        private IMapper _mapper;

        public FleetReadModelWriter(FleetReadDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task CreateDriverAsync(CreateDriverReadModelCommand model, CancellationToken cancellationToken)
        {
            var driver = _mapper.Map<Driver>(model);
            _dbContext.Drivers.Add(driver);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
