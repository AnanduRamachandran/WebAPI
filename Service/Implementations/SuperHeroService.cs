using APIWebApp.Models;
using APIWebApp.Service.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace APIWebApp.Service.Implementations
{
    public class SuperHeroService : ISuperHeroService
    {
        private readonly DataContext _context;

        public SuperHeroService(DataContext dataContext)
        {
            _context = dataContext;
        }

        public async Task<ActionResult<List<SuperHero>>> GetAllHeroes()
        {
            return await _context.SuperHeroes.ToListAsync();
        }

        public async Task AddHero(SuperHero hero)
        {
            _context.SuperHeroes.Add(hero);
            await _context.SaveChangesAsync();
        }

        public async Task<ActionResult<SuperHero>> GetHero(int id)
        {
            var result = await _context.SuperHeroes.FindAsync(id);
            return result;
        }

        public async Task<ActionResult<SuperHero>> ChangeSuperHero(SuperHero changeHero)
        {
            var result = await _context.SuperHeroes.FindAsync(changeHero.Id);
            if (result != null)
            {
                result.Name = changeHero.Name;
                result.FirstName = changeHero.FirstName;
                result.LastName = changeHero.LastName;
                result.Place = changeHero.Place;

                await _context.SaveChangesAsync();
                return await GetHero((int)result.Id);
            }

            return null;
        }

        public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id)
        {
            var result = await _context.SuperHeroes.FindAsync(id);
            if (result != null)
            {
                _context.SuperHeroes.Remove(result);
                await _context.SaveChangesAsync();
                return await  GetAllHeroes();
            }

            return null;
        }
    }
}
