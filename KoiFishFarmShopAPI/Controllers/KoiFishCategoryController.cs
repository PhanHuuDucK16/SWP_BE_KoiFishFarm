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
        public KoiFishCategoryController(UnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        [HttpGet]
        public async
        Task<ActionResult<IEnumerable<KoiFishCategory>>>GetKoiFishCategory()
        {
            return await _unitOfWork.KoiFishCategoryRepository.GetAllAsync();
        }


    }
}
