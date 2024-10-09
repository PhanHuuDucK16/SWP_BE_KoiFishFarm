using KoiFishFarmShop.Models;
using KoiFishFarmShop;
using Microsoft.AspNetCore.Mvc;

namespace KoiFishFarmShopAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FeedbackController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;
        public FeedbackController(UnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        [HttpGet]
        public async
        Task<ActionResult<IEnumerable<Feedback>>> GetFeedback()
        {
            return await _unitOfWork.FeedbackRepository.GetAllAsync();
        }
    }
}
