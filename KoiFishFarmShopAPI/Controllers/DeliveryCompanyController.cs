using KoiFishFarmShop.Models;
using KoiFishFarmShop;
using Microsoft.AspNetCore.Mvc;

namespace KoiFishFarmShopAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeliveryCompanyController : Controller
    {
        private readonly UnitOfWork _unitOfWork;
        public DeliveryCompanyController(UnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        [HttpGet]
        public async
        Task<ActionResult<IEnumerable<DeliveryCompany>>> GetDeliveryCompany()
        {
            return await _unitOfWork.DeliveryCompanyRepository.GetAllAsync();
        }
    }
}
