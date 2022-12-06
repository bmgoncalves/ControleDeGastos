﻿using AutoMapper;
using ControleDeGastos.ApplicationCore.Entities;
using ControleDeGastos.Infra.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

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
        public IActionResult Add(Entries e)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repoEntries.Add(e);
                    return Created(string.Empty, e);
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

        [HttpGet("{id}")]
        public IActionResult GetPorId(int id)
        {
            var e = _repoEntries.GetById(id);
            if (e != null)
            {
                return Ok(e);
            }
            return NotFound();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var lista = _repoEntries.GetAll();
            return Ok(lista);
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
