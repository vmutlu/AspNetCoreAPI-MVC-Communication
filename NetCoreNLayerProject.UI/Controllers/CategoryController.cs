using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NetCoreNLayerProject.API.DTOs;
using NetCoreNLayerProject.UI.ApiServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreNLayerProject.UI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CategoryApiService _categoryApiService;
        private readonly IMapper _mapper;
        public CategoryController(IMapper mapper, CategoryApiService categoryApiService)
        {
            _mapper = mapper;
            _categoryApiService = categoryApiService;
        }
        public async Task<IActionResult> Index()
        {
            var category = await _categoryApiService.GetAllAsync();
            var response = _mapper.Map<IEnumerable<CategoryDTO>>(category).ToList();
            return View(response);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryDTO categoryDTO)
        {
            await _categoryApiService.AddAsync(categoryDTO);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            var category = await _categoryApiService.GetByIdAsync(id);
            return View(_mapper.Map<CategoryDTO>(category));
        }

        [HttpPost]
        public async Task<IActionResult> Update(CategoryDTO categoryDTO)
        {
            await _categoryApiService.Update(categoryDTO);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var category = await _categoryApiService.GetByIdAsync(id);

            await _categoryApiService.Remove(category.Id);

            return RedirectToAction("Index");
        }
    }
}
