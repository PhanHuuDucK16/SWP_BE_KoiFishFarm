using KoiFishFarmShop.Models;
using KoiFishFarmShop;
using Microsoft.AspNetCore.Mvc;

namespace KoiFishFarmShopAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderDetailController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;
        public OrderDetailController(UnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        [HttpGet]
        public async
        Task<ActionResult<IEnumerable<OrderDetail>>>GetOrderDetail()
        {
           return await _unitOfWork.OrderDetailRepository.GetAllAsync();
        }
    }
}
