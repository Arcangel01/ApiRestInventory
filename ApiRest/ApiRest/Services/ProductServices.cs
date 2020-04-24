using ApiRest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRest.Services
{
    public class ProductServices
    {
        private readonly ApiDbContext _context;

        public ProductServices(ApiDbContext context)
        {
            _context = context;
        }

        // Listar los productos
        public List<Productos> getProd()
        {
            var result = _context.Productos.Include(x => x.Categoria).ToList();
            return result;
        }

        // Guardar Los productos
        public Boolean addProduct(Productos _product)
        {
            try
            {
                _context.Productos.Add(_product);
                _context.SaveChanges();
                return true;
            }
            catch (Exception err)
            {
                return false;
            }
        }

        // Actualizar los productos
        public Boolean editarProd(Productos _product)
        {
            try
            {
                var producto = _context.Productos.Where(x => x.ID_PRODUCTO == _product.ID_PRODUCTO).FirstOrDefault();
                producto.CODIGO_PRODUCTO = _product.CODIGO_PRODUCTO;
                producto.NOMBRE_PRODUCTO = _product.NOMBRE_PRODUCTO;
                producto.DESCRIPCION = _product.DESCRIPCION;
                producto.IMAGEN_PROD = _product.IMAGEN_PROD;
                producto.CANTIDAD_PRODUCTO = _product.CANTIDAD_PRODUCTO;
                producto.PRECIO_UNIDAD = _product.PRECIO_UNIDAD;
                producto.ID_CATEGORIA = _product.ID_CATEGORIA;

                _context.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
