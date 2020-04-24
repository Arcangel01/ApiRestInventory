using ApiRest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRest.Services
{
    public class AdminServices
    {
        private readonly ApiDbContext _context;

        public AdminServices(ApiDbContext context)
        {
            _context = context;
        }

        // Login
        public List<Admon> login(string Usuario, string Password)
        {
              var parametro1 = new SqlParameter("@Usuario", Usuario);
              var parametro2 = new SqlParameter("@Password", Password);
              var result = _context.Admons.FromSql("LOGEO @Usuario, @Password", parametro1, parametro2).ToList();
            /* string query = "EXECUTE LOGEO @Usuario='{0}', @Password='{1}' ";
             query = string.Format(query, Usuario, Password);
             List<Admon> login = _context.Admons.FromSql(query).ToList();
             return login;*/
            return result;
            try
            {
            }
            catch (Exception ex)
            {
                return new List<Admon>();
            }

        }

        // Listar los administradores
        public List<Admon> getAdmon()
        {
            var result = _context.Admons.ToList();
            return result;
        }

        // Guardar el Admon
        public Boolean addAdmon(Admon _admon)
        {
            try
            {
                _context.Admons.Add(_admon);
                _context.SaveChanges();
                return true;
            }
            catch (Exception err)
            {
                return false;
            }
        }

        // Actualizar los datos
        public Boolean editarAdmon(Admon _admon)
        {
            try
            {
                var admin = _context.Admons.Where(x => x.ID_ADMON == _admon.ID_ADMON).FirstOrDefault();
                admin.NOMBRE_ADMON = _admon.NOMBRE_ADMON;
                admin.APELLIDO_ADMON = _admon.APELLIDO_ADMON;
                admin.TELEFONO = _admon.TELEFONO;
                admin.DIRECCION = _admon.DIRECCION;
                admin.NICK_NAME = _admon.NICK_NAME;
                admin.PASSWORD_ADMON = _admon.PASSWORD_ADMON;

                _context.SaveChanges();

                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }
    }
}
