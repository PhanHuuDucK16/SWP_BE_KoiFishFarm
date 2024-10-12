using KoiFishFarmShop;
using KoiFishFarmShop.Models;
using KoiFishFarmShop.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KoiFishFarmShopAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KoiFishController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly ILogger<KoiFishController> _logger;

        public KoiFishController(UnitOfWork unitOfWork, ILogger<KoiFishController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        // GET: api/KoiFish
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KoiFish>>> GetKoiFish()
        {
            var koiFishList = await _unitOfWork.KoiFishRepository.GetAllAsync();
            return Ok(koiFishList);
        }

        // GET: api/KoiFish/{id}
        [HttpGet("{id:int}")]
        public async Task<ActionResult<KoiFish>> GetKoiFishById(int id)
        {
            var koiFish = await _unitOfWork.KoiFishRepository.GetByIdAsync(id);
            if (koiFish == null)
            {
                _logger.LogWarning($"KoiFish with ID {id} not found.");
                return NotFound();
            }
            return Ok(koiFish);
        }

        // POST: api/KoiFish
        [HttpPost]
        public async Task<ActionResult<KoiFish>> CreateKoiFish([FromBody] KoiFish koiFish)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid KoiFish model state.");
                return BadRequest(ModelState);
            }

            await _unitOfWork.KoiFishRepository.CreateAsync(koiFish);
            await _unitOfWork.KoiFishRepository.SaveAsync();

            return CreatedAtAction(nameof(GetKoiFishById), new { id = koiFish.Id }, koiFish);
        }

        // PUT: api/KoiFish/{id}
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateKoiFish(int id, [FromBody] KoiFish koiFish)
        {
            if (id != koiFish.Id)
            {
                _logger.LogError("ID in the URL does not match the ID in the body.");
                return BadRequest("ID mismatch.");
            }

            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid KoiFish model state.");
                return BadRequest(ModelState);
            }

            var existingKoiFish = await _unitOfWork.KoiFishRepository.GetByIdAsync(id);
            if (existingKoiFish == null)
            {
                _logger.LogWarning($"KoiFish with ID {id} not found for update.");
                return NotFound();
            }

            _unitOfWork.KoiFishRepository.PrepareUpdate(koiFish);
            await _unitOfWork.KoiFishRepository.SaveAsync();

            return NoContent();
        }

        // DELETE: api/KoiFish/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteKoiFish(int id)
        {
            var koiFish = await _unitOfWork.KoiFishRepository.GetByIdAsync(id);
            if (koiFish == null)
            {
                _logger.LogWarning($"KoiFish with ID {id} not found for deletion.");
                return NotFound();
            }

            _unitOfWork.KoiFishRepository.PrepareRemove(koiFish);
            await _unitOfWork.KoiFishRepository.SaveAsync();

            return NoContent();
        }
    }
}
