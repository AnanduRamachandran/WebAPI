using APIWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using APIWebApp.Service;
using APIWebApp.Service.Abstractions;

namespace APIWebApp.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly ISuperHeroService _heroService;

        public SuperHeroController(ISuperHeroService heroService)
        {
            _heroService = heroService;
        }

        [HttpGet("GetAllSuperHeroes")]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeros()
        {
            var result = await _heroService.GetAllHeroes();
            return Ok(result);
        }

        [HttpPost("AddSuperHero")]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            await _heroService.AddHero(hero);
            return Ok(await _heroService.GetAllHeroes());
        }

        [HttpGet("GetSuperHero/{id}")]
        public async Task<ActionResult<List<SuperHero>>> GetHero(int id)
        {
            var hero = await _heroService.GetHero(id);
            if (hero == null)
            {
                return BadRequest("Hero not found");
            }
            return Ok( await _heroService.GetHero(id));
        }

        [HttpPut("ChangeHero")]
        public async Task<ActionResult<List<SuperHero>>> ChangeHero(SuperHero hero)
        {
            var result = await _heroService.ChangeSuperHero(hero);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("Hero invalid");

        }

        [HttpDelete("DeleteHero/{id}")]
        public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id)
        {
            var result = await _heroService.DeleteHero(id);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("Hero invalid");

        }
    }
}
