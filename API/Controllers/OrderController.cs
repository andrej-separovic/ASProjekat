using Application;
using Application.Commands.Order;
using Application.DataTransfer;
using Application.Queries.Order;
using Application.Search;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;
        private readonly IApplicationActor _actor;

        public OrderController(UseCaseExecutor executor, IApplicationActor aactor)
        {
            _executor = executor;
            _actor = aactor;
        }

        // GET: api/<OrderController>
        [HttpGet]
        public IActionResult Get([FromQuery] OrderSearch search, [FromServices] IGetOrdersQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, search));
        }
        
        // GET: api/<OrderController>
        [HttpGet("userOrders")]
        public IActionResult GetSelfOrder([FromServices] IGetSelfOrdersQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, _actor.Id));
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetOrderQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, id));
        }

        // POST api/<OrderController>
        [HttpPost]
        public IActionResult Post([FromBody] OrderCreateDto dto, [FromServices] ICreateOrderCommand command)
        {
            _executor.ExecuteCommand(command, dto);
            return Ok(StatusCodes.Status201Created);
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] OrderEditDto dto, [FromServices] IEditOrderCommand command)
        {
            dto.Id = id;
            _executor.ExecuteCommand(command, dto);
            return NoContent();
        }
    }
}
