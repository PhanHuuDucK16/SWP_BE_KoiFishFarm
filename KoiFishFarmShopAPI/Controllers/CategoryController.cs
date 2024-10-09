using KoiFishFarmShop.Models;
using KoiFishFarmShop;
using Microsoft.AspNetCore.Mvc;

namespace KoiFishFarmShopAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;
        public CategoryController(UnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        [HttpGet]
        public async
        Task<ActionResult<IEnumerable<Category>>> GetCategory()
        {
            return await _unitOfWork.CategoryRepository.GetAllAsync();
        }
    }
}
