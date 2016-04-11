using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Entities;
using SportsStore.Domain.Abstracts;
using SportsStore.WebUI.Models;

namespace SportsStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository productRepository;

        public ProductController(IProductRepository repository)
        {
            productRepository = repository;
        }

        int pageSize = 4;

        public ViewResult List(string category, int page = 1)
        {
            var allProducts = productRepository.Products;
            var products = allProducts
                .Where(p => category == null || p.Category == category)
                .OrderBy(p => p.ProductID)
                .Skip((page - 1) * pageSize)
                .Take(pageSize);
            var pagingInfo = new PagingInfo
            {
                ItemsPerPage = pageSize,
                CurrentPage = page,
                TotalItems = category == null ? allProducts.Count() : allProducts.Where(p => p.Category == category).Count()
            };
            var viewModel = new ProductsListViewModel
            {
                PagingInfo = pagingInfo,
                Products = products,
                CurrentCategory = category
            };
            return View(viewModel);
        }
    }
}