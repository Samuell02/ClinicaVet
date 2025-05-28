using Microsoft.AspNetCore.Mvc;
using ClinicaVetAPI.Data;
using ClinicaVetAPI.Models;
using ClinicaVetAPI.Repositories.Interfaces;


namespace ClinicaVetAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TutorController : ControllerBase
    {
        private readonly ITutorRepository _Repo;

        public TutorController(ITutorRepository Repo)
        {
            _Repo = Repo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tutor>>> GetTutors()
        {
            return Ok(await _Repo.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tutor>> GetTutor(int id)
        {
            var Tutor = await _Repo.GetByIdAsync(id);
            return Tutor == null ? NotFound() : Ok(Tutor);
        }

        [HttpPost]
        public async Task<ActionResult<Tutor>> CreateTutor(Tutor Tutor)
        {
            var created = await _Repo.AddAsync(Tutor);
            return CreatedAtAction(nameof(GetTutor), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTutor(int id, Tutor Tutor)
        {
            if (id != Tutor.Id) return BadRequest();
            await _Repo.UpdateAsync(Tutor);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTutor(int id)
        {
            await _Repo.DeleteAsync(id);
            return NoContent();
        }
    }
}
