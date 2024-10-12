using KoiFishFarmShop;
using KoiFishFarmShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace KoiFishFarmShopAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KoiFishCategoryController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly ILogger<KoiFishController> _logger;

        public KoiFishCategoryController(UnitOfWork unitOfWork, ILogger<KoiFishController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        // GET: api/KoiFishCategory
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KoiFishCategory>>> GetKoiFishCategory()
        {
            var koiFishCategoryList = await _unitOfWork.KoiFishCategoryRepository.GetAllAsync();
            return Ok(koiFishCategoryList);
        }

        // GET: api/KoiFishCategory/{id}
        [HttpGet("{id:int}")]
        public async Task<ActionResult<KoiFishCategory>> GetKoiFishById(int id)
        {
            var koiFishCategory = await _unitOfWork.KoiFishCategoryRepository.GetByIdAsync(id);
            if (koiFishCategory == null)
            {
                _logger.LogWarning($"KoiFishCategory with ID {id} not found.");
                return NotFound();
            }
            return Ok(koiFishCategory);
        }


    }
}
