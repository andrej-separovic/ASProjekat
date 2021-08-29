using Application;
using Application.Commands.Brand;
using Application.DataTransfer;
using Application.Queries.Brand;
using Application.Search;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;

        public BrandController(UseCaseExecutor executor)
        {
            _executor = executor;
        }
        [AllowAnonymous]
        // GET: api/<BrandController>
        [HttpGet]
        public IActionResult Get([FromQuery] BrandSearch search, [FromServices] IGetBrandsQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, search));
        }
        [AllowAnonymous]
        // GET api/<BrandController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetBrandQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, id));
        }

        // POST api/<BrandController>
        [HttpPost]
        public IActionResult Post([FromBody] BrandCreateDto dto, [FromServices] ICreateBrandCommand command)
        {
            _executor.ExecuteCommand(command, dto);
            return Ok(StatusCodes.Status201Created);
        }

        // PUT api/<BrandController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] BrandDto dto, [FromServices] IEditBrandCommand command)
        {
            dto.Id = id;
            _executor.ExecuteCommand(command, dto);
            return NoContent();
        }

        // DELETE api/<BrandController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteBrandCommand command)
        {
            _executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }
}
