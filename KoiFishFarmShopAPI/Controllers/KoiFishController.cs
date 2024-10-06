using KoiFishFarmShop;
using KoiFishFarmShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace KoiFishFarmShopAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KoiFishController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;
        public KoiFishController(UnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        [HttpGet]
        public async 
        Task<ActionResult<IEnumerable<KoiFish>>> GetKoiFish()
        {
            return await _unitOfWork.KoiFishRepository.GetAllAsync();
        }


    }
}
