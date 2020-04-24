using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiRest.Models;
using ApiRest.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdmonController : ControllerBase
    {
        private readonly AdminServices _service;
        public AdmonController(AdminServices service)
        {
            _service = service;
        }

        // Login
        [HttpGet]
        [Route("auth/{Usuario}/{Password}")]
        public IActionResult logeo(string user, string pass)
        {
            return Ok(_service.login(user, pass));
        }

        // Metodo Http para obtener los administradores
        [HttpGet]
        [Route("users")]
        public IActionResult obtAdmin()
        {
            var result = _service.getAdmon();
            return Ok(result);
        }

        [HttpPost] // Almacenar un admin
        [Route("users")]
        public IActionResult agregar([FromBody] Admon _admin)
        {
            var result = _service.addAdmon(_admin);
            if (result)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut] // Editar un admin
        [Route("users")]
        public IActionResult editar([FromBody] Admon _admin)
        {
            var result = _service.editarAdmon(_admin);
            if (result)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}