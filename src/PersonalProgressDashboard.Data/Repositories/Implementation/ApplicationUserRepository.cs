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
  public class ApplicationUserRepository : IApplicationUserRepository
  {
    private readonly ApplicationDbContext _context;
    public ApplicationUserRepository(ApplicationDbContext context)
    {
      _context = context;
    }

    public async Task<ApplicationUser> GetUserAsync(string id)
    {
      try
      {
        return await _context.Users.FirstAsync(e => e.Id == id);
      }
      catch (Exception ex)
      {
        //todo: add in logging
        throw;
      }
    }
    public async Task<ApplicationUser> UpdateUserAsync(ApplicationUser m)
    {
      try
      {
        var u = await GetUserAsync(m.Id);
        u.UserName = m.UserName;
        u.FirstName = m.FirstName;
        u.LastName = m.LastName;
        u.Sex = m.Sex;
        u.Age = m.Age;
        u.HeightCm = m.HeightCm;
        u.IsMetric = m.IsMetric;
        u.LastUpdated = DateTime.UtcNow;

        var response = _context.Users.Update(u).Entity;
        await _context.SaveChangesAsync();
        return u;
      }
      catch (Exception ex)
      {
        //todo: add in logging
        throw;
      }
    }
  }
}
