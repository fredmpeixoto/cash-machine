using CashMachine.Domain.Interfaces.Services;
using CashMachine.Domain.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CashMachine.Api.Controllers
{
    [EnableCors("CorsPolicy")]

    [Produces("application/json")]
    [Route("api/Account")]
    public class AccountController : Controller
    {
        private IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        // GET: api/Account/5
        [Authorize("Bearer")]
        [HttpGet("{idUser}", Name = "Get")]
        public IActionResult Get(string idUser)
        {
            try
            {
                return Ok(_accountService.ObterPorIdUser(idUser));
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        // GET: api/Account/5/123
        [HttpGet("{id}/{value}", Name = "GetValues")]
        public IActionResult GetValues(string id, double value)
        {
            try
            {
                return Ok(_accountService.RemoveMoney(id, value));
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        // POST: api/Account
        [Authorize("Bearer")]
        [HttpPost]
        public IActionResult Post([FromBody]AccountVM value)
        {
            try
            {
                if (ModelState.IsValid)
                    return Ok(_accountService.Adicionar(value));
                else
                    return BadRequest(ModelState);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }




    }
}
