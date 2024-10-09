using KoiFishFarmShop.Models;
using KoiFishFarmShop;
using Microsoft.AspNetCore.Mvc;

namespace KoiFishFarmShopAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;
        public CustomerController(UnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        [HttpGet]
        public async
        Task<ActionResult<IEnumerable<Customer>>> GetCustomer()
        {
            return await _unitOfWork.CustomerRepository.GetAllAsync();
        }
    }
}
