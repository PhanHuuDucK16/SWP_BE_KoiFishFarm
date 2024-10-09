using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiFishFarmShop.Base;
using KoiFishFarmShop.Models;

namespace KoiFishFarmShop.Repositories
{
    public class DeliveryCompanyRepository : GenericRepository<DeliveryCompany>
    {
        public DeliveryCompanyRepository(KoiFishFarmShopContext context) => _context = context; 
    }
}
