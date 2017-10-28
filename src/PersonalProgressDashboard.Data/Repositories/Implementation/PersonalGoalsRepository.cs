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
    public class PersonalGoalsRepository : IPersonalGoalsRepository
    {
        private readonly ApplicationDbContext _context;
        public PersonalGoalsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<PersonalGoals>> GetAllPersonalGoalsAsync()
        {
            try
            {
                //add id to search so only bring back user's items once identity is in
                return await _context.PersonalGoals.Select(e => e).OrderBy(e => e.Created).ToListAsync();
            }
            catch (Exception ex)
            {
                //todo: add in logging
                throw;
            }
        }

        public async Task<PersonalGoals> GetPersonalGoalByIdAsync(int id)
        {
            try
            {
                return await _context.PersonalGoals.FirstOrDefaultAsync(e => e.Id == id);
            }
            catch (Exception ex)
            {
                //todo: add in logging
                throw;
            }
        }

        public async Task AddGoalAsync(PersonalGoals m)
        {
            try
            {
                if (m == null) throw new InvalidOperationException("Unable to add a null entity to the repository.");

                await _context.PersonalGoals.AddAsync(m);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                //todo: add in logging
                throw;
            }
        }

        public async Task AddGoalsRangeAsync(List<PersonalGoals> goals)
        {
            try
            {
                if (goals == null) throw new InvalidOperationException("Unable to add a null entities to the repository.");

                _context.AddRange(goals);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                //todo: add in logging
                throw;
            }
        }

        public async Task<bool> UpdateGoalAsync(PersonalGoals m)
        {
            try
            {
                if (m == null) throw new InvalidOperationException("Unable to add a null entity to the repository.");
                if (m.ApplicationUserId == null) throw new InvalidOperationException("Unable to update a null entity to the repository.");

                var goal = await GetPersonalGoalByIdAsync(m.Id);
                goal.AchievedDate = m.AchievedDate;
                goal.AchieveByDate = m.AchieveByDate;
                goal.GoalText = m.GoalText;

                var response = _context.PersonalGoals.Update(goal).Entity;
                await _context.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {
                //todo: add in logging
                return false;
            }
        }

        public async Task DeleteGoalAsync(int id)
        {
            try
            {
                var goal = await GetPersonalGoalByIdAsync(id);
                var r = _context.PersonalGoals.Remove(goal).Entity;
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                //todo: add in logging
                throw;
            }
        }


        public async Task DANGER_DeleteAllGoalsAsync()
        {
            try
            {
                var goals = await GetAllPersonalGoalsAsync();
                _context.PersonalGoals.RemoveRange(goals);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                //todo: add in logging
                throw;
            }
        }

    }
}
