using APIWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace APIWebApp.Service.Abstractions
{
    public interface ISuperHeroService
    {
        Task<ActionResult<List<SuperHero>>> GetAllHeroes();
        Task AddHero(SuperHero hero);
        Task<ActionResult<SuperHero>> GetHero(int id);
        Task<ActionResult<SuperHero>> ChangeSuperHero(SuperHero changeHero);
        Task<ActionResult<List<SuperHero>>> DeleteHero(int id);
    }
}
