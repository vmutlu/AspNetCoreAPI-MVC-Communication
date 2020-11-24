using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NetCoreNLayerProject.API.DTOs;
using NetCoreNLayerProject.Core.Models;
using NetCoreNLayerProject.Core.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetCoreNLayerProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IService<Person> _personService;
        private readonly IMapper _mapper;

        public PersonsController(IService<Person> personService, IMapper mapper)
        {
            _personService = personService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var persons = await _personService.GetAllAsync();

            return Ok(_mapper.Map<IEnumerable<PersonDTO>>(persons));
        }

        [HttpPost]
        public async Task<IActionResult> Save(PersonDTO person)
        {
            var newPerson = await _personService.AddAsync(_mapper.Map<Person>(person));
            return Ok(_mapper.Map<PersonDTO>(newPerson));
        }
    }
}
