using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NetCoreNLayerProject.API.DTOs;
using NetCoreNLayerProject.UI.ApiServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreNLayerProject.UI.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductApiService _productApiService;
        private readonly IMapper _mapper;
        public ProductController(IMapper mapper, ProductApiService productApiService)
        {
            _mapper = mapper;
            _productApiService = productApiService;
        }
        public async Task<IActionResult> Index()
        {
            var products = await _productApiService.GetAllAsync();
            var response = _mapper.Map<IEnumerable<ProductDTO>>(products).ToList();
            return View(response);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductDTO productDTO)
        {
            await _productApiService.AddAsync(productDTO);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            var product = await _productApiService.GetByIdAsync(id);
            return View(_mapper.Map<ProductDTO>(product));
        }

        [HttpPost]
        public async Task<IActionResult> Update(ProductDTO productDTO)
        {
            await _productApiService.UpdateAsync(productDTO);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var productDTO = await _productApiService.GetByIdAsync(id);

            await _productApiService.Remove(productDTO.Id);

            return RedirectToAction("Index");
        }

        public async Task<ProductDTO> GetWithCategoryByIdAsync(int productId)
        {
            return  await _productApiService.GetWithCategoryByIdAsync(productId);
        }
    }
}
