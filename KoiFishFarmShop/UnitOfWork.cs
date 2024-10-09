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
        private ManagerRepository _managerRepository;
        private CategoryRepository _categoryRepository;
        private CustomerRepository _customerRepository;
        private FeedbackRepository _feedbackRepository;
        private DeliveryCompanyRepository _deliveryCompanyRepository;
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

        public ManagerRepository ManagerRepository
        {
            get { return _managerRepository ??= new ManagerRepository(_context); }
        }

        public CategoryRepository CategoryRepository
        {
            get { return _categoryRepository ??= new CategoryRepository(_context); }
        }

        public CustomerRepository CustomerRepository
        {
            get { return _customerRepository ??= new CustomerRepository(_context); }
        }

        public FeedbackRepository FeedbackRepository
        {
            get { return _feedbackRepository ??= new FeedbackRepository(_context); }

        }

        public DeliveryCompanyRepository DeliveryCompanyRepository
        {
            get { return _deliveryCompanyRepository ??= new DeliveryCompanyRepository(_context); }
        }
    }
}
