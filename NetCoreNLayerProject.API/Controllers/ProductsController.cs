using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NetCoreNLayerProject.API.DTOs;
using NetCoreNLayerProject.API.Filters;
using NetCoreNLayerProject.Core.Models;
using NetCoreNLayerProject.Core.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetCoreNLayerProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAllAsync();

            return Ok(_mapper.Map<IEnumerable<ProductDTO>>(products));
        }

        [ServiceFilter(typeof(NotFoundFilter))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var products = await _productService.GetByIdAsync(id);

            return Ok(_mapper.Map<ProductDTO>(products));
        }

        [ValidationFilter]
        [HttpPost]
        public async Task<IActionResult> Save(ProductDTO productDTO)
        {
            var product = await _productService.AddAsync(_mapper.Map<Product>(productDTO));

            return Created(string.Empty, _mapper.Map<ProductDTO>(product));
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductDTO productDTO)
        {
            _productService.Update(_mapper.Map<Product>(productDTO));

            return NoContent();
        }

        [ValidationFilter]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = _productService.GetByIdAsync(id).Result; //buradaki result async ve waitten kurtarır
            _productService.Remove(product);

            return NoContent();
        }

        [ValidationFilter]
        [HttpGet("{id}/category")]
        public async Task<IActionResult> GetWithCategoryById(int id)
        {
            var products = await _productService.GetWithCategoryByIdAsync(id);

            return Ok(_mapper.Map<ProductWithCategoryDTO>(products));
        }
    }
}
