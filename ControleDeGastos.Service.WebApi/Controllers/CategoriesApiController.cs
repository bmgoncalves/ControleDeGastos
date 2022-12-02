using AutoMapper;
using ControleDeGastos.ApplicationCore.Entities;
using ControleDeGastos.ApplicationCore.Models;
using ControleDeGastos.Infra.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeGastos.Service.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesApiController : ControllerBase
    {

        private readonly ILogger<CategoriesApiController> _logger;
        private readonly ICategoryRepository _repoCategories;
        private readonly IMapper _mapper;

        public CategoriesApiController(ILogger<CategoriesApiController> logger, ICategoryRepository repoCategories, IMapper mapper)
        {
            _logger = logger;
            _repoCategories = repoCategories;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Add(CategoryViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var c = _mapper.Map<Category>(model);
                    _repoCategories.Add(c);
                    return Created(string.Empty, c);
                }
                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Update(Category c)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repoCategories.Update(c);
                    return Ok();
                }
                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _repoCategories.Delete(id);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var c = _repoCategories.GetById(id);
            if (c != null)
            {
                return Ok(c);
            }
            return NoContent();

        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var lista = _repoCategories.GetAll();
            return Ok(lista);
        }

    }
}
