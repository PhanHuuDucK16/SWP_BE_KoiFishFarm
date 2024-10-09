using KoiFishFarmShop.Models;
using KoiFishFarmShop;
using Microsoft.AspNetCore.Mvc;

namespace KoiFishFarmShopAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ManagerController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;
        public ManagerController(UnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        [HttpGet]
        public async
        Task<ActionResult<IEnumerable<Manager>>> GetManager()
        {
            return await _unitOfWork.ManagerRepository.GetAllAsync();
        }
    }
}
