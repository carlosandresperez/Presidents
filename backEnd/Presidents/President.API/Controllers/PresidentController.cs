using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PresidentES.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace President.API.Controllers
{
    [Route("api/[controller]")]
    public class PresidentController : Controller
    {
        private readonly IPresidentService _service;

        public PresidentController(IPresidentService service)
        {
            _service = service;
        }

        [EnableCors("miPolitica")]
        [HttpGet("getListOfPresidents")]
        public async Task<IActionResult> getListOfPresidents(bool orderDescending)
        {
            try
            {
                return Ok(await _service.getListOfPresidents(orderDescending));
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
