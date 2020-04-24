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
    public class CategoryController : ControllerBase
    {
        private readonly CategoriaServices _service;
        public CategoryController(CategoriaServices service)
        {
            _service = service;
        }

        // Metodo Http para obtener las categorias
        [Route("cat")]
        public IActionResult obtCat()
        {
            var result = _service.getCategory();
            return Ok(result);
        }

        [HttpPost] // Almacenar una categoria
        [Route("cat")]
        public IActionResult agregar([FromBody] Categoria _cat)
        {
            var result = _service.addCategory(_cat);
            if (result)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut] // Editar categoria
        [Route("cat")]
        public IActionResult editar([FromBody] Categoria _cat)
        {
            var result = _service.editarCategory(_cat);
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