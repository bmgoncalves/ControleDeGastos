using AutoMapper;
using ControleDeGastos.ApplicationCore.Entities;
using ControleDeGastos.ApplicationCore.Models;
using ControleDeGastos.Infra.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeGastos.Service.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize(AuthenticationSchemes = "JwtBearer")]

    public class EntriesApiController : ControllerBase
    {
        private readonly ILogger<EntriesApiController> _logger;
        private readonly IEntriesRepository _repoEntries;
        private readonly IMapper _mapper;
        public EntriesApiController(ILogger<EntriesApiController> logger, IEntriesRepository repoEntries, IMapper mapper)
        {
            _logger = logger;
            _repoEntries = repoEntries;
            _mapper = mapper;
        }


        [HttpPost]
        public IActionResult Add(EntriesViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var entry = _mapper.Map<Entries>(model);
                    _repoEntries.Add(entry);
                    return Created(string.Empty, entry);
                }
                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }

        }

        [HttpPut]
        public IActionResult Update(Entries e)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repoEntries.Update(e);
                    return Ok();
                }
                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException != null ? ex.InnerException.Message : ex.Message);

            }
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _repoEntries.Delete(id);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetPorId(int id)
        {
            var e = _repoEntries.GetById(id);
            if (e != null)
            {
                return Ok(e);
            }
            return NotFound();
        }


        [HttpGet("{id}/{first}/{second}")]
        public IActionResult GetPorParamentro()
        {
            return Ok();
        }

        [HttpGet("{data}")]
        public IActionResult GetPorData(DateTime d)
        {
            var list = _repoEntries.GetByDate(d);
            return Ok(list);
        }
    }
}
