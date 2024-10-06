using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiFishFarmShop.Base;
using KoiFishFarmShop.Models;

namespace KoiFishFarmShop.Repositories
{
    public class KoiFishCategoryRepository : GenericRepository<KoiFishCategory>
    {
        public KoiFishCategoryRepository(KoiFishFarmShopContext context) => _context = context;
    }
}