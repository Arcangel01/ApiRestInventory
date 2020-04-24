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
    public class FacturaController : ControllerBase
    {
        private readonly FacturaServices _service;
        private readonly ApiDbContext _context;

        public FacturaController(FacturaServices service)
        {
            _service = service;
        }

        [HttpGet]// Metodo Http para obtener las facturas
        [Route("fact")]
        public IActionResult obtFact()
        {
            var result = _service.getFacturas();
            return Ok(result);
        }

        [HttpPost] // Almacenar una factura
        [Route("fact")]
        public IActionResult agregar([FromBody] Factura _fact)
        {
            var result = _service.addFactura(_fact);
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