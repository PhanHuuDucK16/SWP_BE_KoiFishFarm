using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiFishFarmShop.Models;
using KoiFishFarmShop.Repositories;
using Microsoft.EntityFrameworkCore;

namespace KoiFishFarmShop
{
    public class UnitOfWork
    {
        private KoiFishFarmShopContext _context;
        private KoiFishRepository _koiFishRepository;
        private KoiFishCategoryRepository _koiFishCategoryRepository;
        private OrderRepository _orderRepository;
        private OrderDetailRepository _orderDetailRepository;
        private UserRepository _userRepository;
        public UnitOfWork() => _context = new KoiFishFarmShopContext();

        public KoiFishRepository KoiFishRepository
        {  
            get { return _koiFishRepository ??= new KoiFishRepository(_context); } 
        }

        public KoiFishCategoryRepository KoiFishCategoryRepository
        {
            get { return _koiFishCategoryRepository ??= new KoiFishCategoryRepository(_context); }
        }

        public OrderRepository OrderRepository
        {
            get { return _orderRepository ??= new OrderRepository(_context); }
        }

        public OrderDetailRepository OrderDetailRepository
        {
            get { return _orderDetailRepository ??= new OrderDetailRepository(_context); }
        }

        public UserRepository UserRepository
        {
            get { return _userRepository ??= new UserRepository(_context); }
        }
    }
}
