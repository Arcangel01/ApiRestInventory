using ApiRest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRest.Services
{
    public class CategoriaServices
    {
        private readonly ApiDbContext _context;

        public CategoriaServices(ApiDbContext context)
        {
            _context = context;
        }

        // Listar las categorias
        public List<Categoria> getCategory()
        {
            var result = _context.Categorias.ToList();
            return result;
        }


        // Guardar categoria
        public Boolean addCategory(Categoria _cat)
        {
            try
            {
                _context.Categorias.Add(_cat);
                _context.SaveChanges();
                return true;
            }
            catch (Exception err)
            {
                return false;
            }
        }

        // Actualizar los datos
        public Boolean editarCategory(Categoria _cat)
        {
            try
            {
                var categoria = _context.Categorias.Where(x => x.ID_CATEGORIA == _cat.ID_CATEGORIA).FirstOrDefault();
                categoria.NOMBRE_CATEGORIA = _cat.NOMBRE_CATEGORIA;

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
