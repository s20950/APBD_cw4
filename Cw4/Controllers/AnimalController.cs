

using Cw4.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cw4.Models
{
    [ApiController]
    [Route("api/animals")]
    public class AnimalController : ControllerBase
    {
        private IDatabaseService _dbService;

        public AnimalController(IDatabaseService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet]
        public IActionResult GetAnimals()
        {
            return Ok(_dbService.GetAnimals());
        }

        [HttpGet("{idAnimal}")]
        public IActionResult GetAnimal([FromRoute] int idAnimal)
        {
            return Ok(_dbService.GetAnimal(idAnimal));
        }

        [HttpPost]
        public IActionResult CreateAnimal(Animal newAnimal)
        {
            return Ok(_dbService.CreateAnimal(newAnimal));
        }
        [HttpPut("{idAnimal}")]
        public IActionResult UpdateAnimal([FromRoute] int idAnimal, Animal UpdatedAnimal)
        {
            return Ok(_dbService.UpdateAnimal(idAnimal, UpdatedAnimal));
        }
        [HttpDelete("{idAnimal}")]
        public IActionResult DeleteAnimal([FromRoute] int idAnimal)
        {
            return Ok(_dbService.DeleteAnimal(idAnimal));
        }
    }
}