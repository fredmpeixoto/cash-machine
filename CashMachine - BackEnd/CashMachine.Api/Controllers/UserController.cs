using CashMachine.Domain.Interfaces;
using CashMachine.Domain.ViewModel;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CashMachine.Api.Controllers
{
    [EnableCors("CorsPolicy")]

    [Produces("application/json")]
    [Route("api/User")]
    public class UserController : Controller
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        // GET: api/User
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_userService.ObterTodos());
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "GetUser")]
        public IActionResult GetUser(string id)
        {
            try
            {
                return Ok(_userService.ObterPorId(id));
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        // POST: api/User
        [HttpPost]
        public IActionResult Post([FromBody]UserVM value)
        {
            try
            {
                if (ModelState.IsValid)
                    return Ok(_userService.Adicionar(value));
                else
                    return BadRequest(ModelState);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody]UserVM value)
        {
            try
            {
                return Ok(_userService.Atualizar(id, value));
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                return Ok(_userService.Remover(id));
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
