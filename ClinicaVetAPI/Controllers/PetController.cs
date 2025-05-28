using Microsoft.AspNetCore.Mvc;
using ClinicaVetAPI.Data;
using ClinicaVetAPI.Models;
using ClinicaVetAPI.Repositories.Interfaces;


namespace ClinicaVetAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetController : ControllerBase
    {
        private readonly IPetRepository _Repo;

        public PetController(IPetRepository Repo)
        {
            _Repo = Repo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pet>>> GetPets()
        {
            return Ok(await _Repo.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pet>> GetPet(int id)
        {
            var Pet = await _Repo.GetByIdAsync(id);
            return Pet == null ? NotFound() : Ok(Pet);
        }

        [HttpPost]
        public async Task<ActionResult<Pet>> CreatePet(Pet Pet)
        {
            var created = await _Repo.AddAsync(Pet);
            return CreatedAtAction(nameof(GetPet), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePet(int id, Pet Pet)
        {
            if (id != Pet.Id) return BadRequest();
            await _Repo.UpdateAsync(Pet);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePet(int id)
        {
            await _Repo.DeleteAsync(id);
            return NoContent();
        }
    }
}
