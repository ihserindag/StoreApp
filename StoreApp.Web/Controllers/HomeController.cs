using Microsoft.AspNetCore.Mvc;
using StoreApp.Data.Abstract;
using StoreApp.Web.Models;
namespace StoreApp.Web.controllers

{
    public class HomeController:Controller
    {
        private IStoreRepository _storeRepository;
        public HomeController(IStoreRepository storeRepository)
        {
            _storeRepository=storeRepository;
        }
        
        public async Task<IActionResult> Index()
        {
            var Products=_storeRepository.Products.Select(p=>new ProductViewModel{
               Id=p.Id,
               Name=p.Name,
               Price=p.Price,
               Description=p.Description,
               Category=p.Category
            }).ToList();
            return View(Products);
        }
    }
}