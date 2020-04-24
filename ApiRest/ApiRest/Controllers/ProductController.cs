using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ApiRest.Models;
using ApiRest.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ApiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductServices _service;
        private readonly ApiDbContext _context;
        public IHostingEnvironment Env { get; set; }
        public ProductController(ProductServices service, ApiDbContext context, Microsoft.AspNetCore.Hosting.IHostingEnvironment environment)
        {
            _service = service;
            _context = context;
            Env = environment;
        }

        // Metodo Http para obtener los productos
        [Route("prod")]
        public IActionResult obtProd()
        {
            var result = _service.getProd();
            return Ok(result);
        }

        [HttpPost] // Almacenar un producto
        [Route("prod")]
        public async Task<IActionResult> postProduct([FromForm] string product, IFormFile imagen)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Productos _product = JsonConvert.DeserializeObject<Productos>(product);
            try
            {
                if (string.IsNullOrEmpty(_product.CODIGO_PRODUCTO))
                    throw new ArgumentException("El producto debe de contener un codigo");

                _product.IMAGEN_PROD = Guid.NewGuid() + imagen.FileName;
                _context.Productos.Add(_product);
                await _context.SaveChangesAsync();

                var prodb = _context.Productos.FirstOrDefault(x => x.NOMBRE_PRODUCTO == _product.NOMBRE_PRODUCTO);

                    var Ruta = Path.Combine(Env.WebRootPath, "files");

                    if (!Directory.Exists(Ruta))
                    {
                        Directory.CreateDirectory(Ruta);
                    }

                    using (var stream = new FileStream(Path.Combine(Ruta, _product.IMAGEN_PROD), FileMode.Create))
                    {
                        await imagen.CopyToAsync(stream);
                    }

                return Ok();
            }
            catch(Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet("{URL}")]
        public FileStreamResult GetImage([FromRoute]string URL)
        {
            try
            {
                var ruta = Path.Combine(Env.WebRootPath, "files");
                var stream = System.IO.File.OpenRead(Path.Combine(ruta, URL));
                return File(stream, "image/jpg");
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        [HttpPut] // Editar un admin
        [Route("prod")]
        public IActionResult editar([FromBody]  Productos _prod)
        {
            var result = _service.editarProd(_prod);
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