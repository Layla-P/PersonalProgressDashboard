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

    public async Task<PersonalMantras> GetPersonalMantraById(int id)
    {
      try
      {
        return await _context.PersonalMantras.FirstOrDefaultAsync(e => e.Id == id);
      }
      catch (Exception ex)
      {
        //todo: add in logging
        throw;
      }
    }

    public async void AddMantra(PersonalMantras m)
    {
      try
      {
        if (m == null) throw new InvalidOperationException("Unable to add a null entity to the repository.");

        await _context.PersonalMantras.AddAsync(m);
        _context.SaveChanges();

      }
      catch (Exception ex)
      {
        //todo: add in logging
        throw;
      }
    }

    public async Task<bool> UpdateMantra(PersonalMantras m)
    {
      try
      {
        if (m == null) throw new InvalidOperationException("Unable to add a null entity to the repository.");
        if (m.ApplicationUserId == null) throw new InvalidOperationException("Unable to update a null entity to the repository.");

        var mantra = await GetPersonalMantraById(m.Id);
        mantra.MantraText = m.MantraText;

        var response = _context.PersonalMantras.Update(mantra).Entity;
        await _context.SaveChangesAsync();
        return true;

      }
      catch (Exception ex)
      {
        //todo: add in logging
        return false;
      }
    }

    public async void DeleteMantra(int id)
    {
      try
      {
        var mantra = await GetPersonalMantraById(id);
        var m = _context.PersonalMantras.Remove(mantra).Entity;
        _context.SaveChanges();

      }
      catch (Exception ex)
      {
        //todo: add in logging
        throw;
      }
    }
  }
}
