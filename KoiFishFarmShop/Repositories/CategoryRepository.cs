using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiFishFarmShop.Base;
using KoiFishFarmShop.Models;
using Microsoft.EntityFrameworkCore;

namespace KoiFishFarmShop.Repositories
{
    public class CategoryRepository : GenericRepository<Category>
    {
        public CategoryRepository(KoiFishFarmShopContext context) => _context = context;

    }
}
