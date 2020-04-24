using ApiRest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRest.Services
{
    public class FacturaServices
    {
        private readonly ApiDbContext _context;

        public FacturaServices(ApiDbContext context)
        {
            _context = context;
        }

        // Listar los productos
        public List<Factura> getFacturas()
        {
            var result = _context.Facturas.Include(x => x.Productos).ToList();
            return result;
        }

        // Guardar Los productos
        public Boolean addFactura(Factura _factura)
        {
            try
            {
                _context.Facturas.Add(_factura);
                _context.SaveChanges();
                return true;
            }
            catch (Exception err)
            {
                return false;
            }
        }
    }
}
