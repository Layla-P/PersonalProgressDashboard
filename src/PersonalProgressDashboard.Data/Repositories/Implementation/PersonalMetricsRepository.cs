using System;
using System.Collections.Generic;
using System.Linq;
using PersonalProgressDashboard.Data.Context;
using PersonalProgressDashboard.Domain.Enitities;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersonalProgressDashboard.Data.Repositories.Interfaces;

namespace PersonalProgressDashboard.Data.Repositories.Implementation
{
    public class PersonalMetricsRepository : IPersonalMetricsRepository
    {
        private readonly ApplicationDbContext _context;
        public PersonalMetricsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<PersonalMetrics>> GetAllPersonalMetrics()
        {
            try
            {
                return await _context.PersonalMetrics.Select(e => e).OrderBy(e=>e.Created).ToListAsync();
            }
            catch (Exception ex)
            {
                //todo: add in logging
                throw;
            }
        }
    }
}
