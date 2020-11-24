using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NetCoreNLayerProject.API.DTOs;
using NetCoreNLayerProject.Web.ApiServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetCoreNLayerProject.Web.Controllers
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

            return View(_mapper.Map<IEnumerable<CategoryDTO>>(category));
        }
    }
}
