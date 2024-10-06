using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiFishFarmShop.Base;
using KoiFishFarmShop.Models;

namespace KoiFishFarmShop.Repositories
{
    public class UserRepository : GenericRepository<User>
    {
        public UserRepository(KoiFishFarmShopContext context) => _context = context;
    }
}