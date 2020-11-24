using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NetCoreNLayerProject.API.DTOs;
using NetCoreNLayerProject.Core.Models;
using NetCoreNLayerProject.Core.Service;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetCoreNLayerProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<CategoryDTO>>(categories));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var categories = await _categoryService.GetByIdAsync(id);
            return Ok(_mapper.Map<CategoryDTO>(categories));
        }

        [HttpPost]
        public async Task<IActionResult> Save(CategoryDTO categoryDTO)
        {
           var category = await _categoryService.AddAsync(_mapper.Map<Category>(categoryDTO));

            return Created(string.Empty, _mapper.Map<CategoryDTO>(category));
        }

        [HttpPut]
        public async Task<IActionResult> Update(CategoryDTO categoryDTO)
        {
            _categoryService.Update(_mapper.Map<Category>(categoryDTO));

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var category = _categoryService.GetByIdAsync(id).Result; //buradaki result async ve waitten kurtarır
            _categoryService.Remove(category);

            return NoContent();
        }

        [HttpGet("{id}/product")]
        public async Task<IActionResult> GetWithProductById(int id)
        {
            var category = await _categoryService.GetWithProductByIdAsync(id);

            return Ok(_mapper.Map<CategoryWithProductDTO>(category));
        }
    }
}
