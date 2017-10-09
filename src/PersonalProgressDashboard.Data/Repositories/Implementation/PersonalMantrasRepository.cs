using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersonalProgressDashboard.Data.Context;
using PersonalProgressDashboard.Data.Repositories.Interfaces;
using PersonalProgressDashboard.Domain.Enitities;

namespace PersonalProgressDashboard.Data.Repositories.Implementation
{
    public class PersonalMantrasRepository : IPersonalMantrasRepository
    {
        private readonly ApplicationDbContext _context;
        public PersonalMantrasRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<PersonalMantras>> GetAllPersonalMantras()
        {
            try
            {
                return await _context.PersonalMantras.Select(e => e).OrderBy(e => e.Created).ToListAsync();
            }
            catch (Exception ex)
            {
                //todo: add in logging
                throw;
            }
        }
    }
}
