using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StoreApp.Data.Abstract;
using StoreApp.Web.Models;

namespace StoreApp.Web.Controllers
{
    public class HomeController : Controller
    {
        public int pageSize = 3;
        private readonly IStoreRepository _storeRepository;
        private readonly IMapper _mapper;

        public HomeController(IStoreRepository storeRepository, IMapper mapper)
        {
            _storeRepository = storeRepository;
            _mapper = mapper;
        }

        public IActionResult Index(string? category, int page = 1)
        {
            var totalItems = _storeRepository.GetProductCount(category);

            var products = _storeRepository.GetProducts(category, page, pageSize);
            var productViewModels = _mapper.Map<List<ProductViewModel>>(products);

            return View(
                new ProductListViewModel
                {
                    Products = productViewModels,
                    PageInfo = new PageInfo
                    {
                        TotalItems = totalItems,
                        ItemsPerPage = pageSize,
                        CurrentPage = page
                    }
                }
            );
        }
    }
}
