using Microsoft.AspNetCore.Mvc;
using StoreApp.Data.Abstract;
using StoreApp.Web.Models;
namespace StoreApp.Web.controllers

{
    public class HomeController:Controller
    {
        public int pageSize=3;
        private IStoreRepository _storeRepository;
        public HomeController(IStoreRepository storeRepository)
        {
            _storeRepository=storeRepository;
        }
        
        //localhost:5000/Home/Index?page=1
        public async Task<IActionResult> Index(int page=1)
        {
            var Products=_storeRepository
            .Products
            .Skip((page-1)*pageSize)
            .Take(pageSize)
            .Select(p=>
                new ProductViewModel{
                    Id=p.Id,
                    Name=p.Name,
                    Price=p.Price,
                    Description=p.Description,
                    Category=p.Category
                }).ToList();

            return View(
                new ProductListViewModel
            {
                    Products=Products,
                    PageInfo=new PageInfo
                    {
                        TotalItems=_storeRepository.Products.Count(),
                        ItemsPerPage=pageSize,
                        CurrentPage=page
                    }
                }
                );
        }
    }
}