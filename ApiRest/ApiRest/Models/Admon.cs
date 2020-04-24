using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRest.Models
{
    public class Admon
    {
        public int ID_ADMON { get; set; }
        public string NOMBRE_ADMON { get; set; }
        public string APELLIDO_ADMON { get; set; }
        public string TELEFONO { get; set; }
        public string DIRECCION { get; set; }
        public string NICK_NAME { get; set; }
        public string PASSWORD_ADMON { get; set; }

        public class MapeoAdmin
        {
            public MapeoAdmin(EntityTypeBuilder<Admon> mapAdmon)
            {
                mapAdmon.HasKey(x => x.ID_ADMON);
                mapAdmon.Property(x => x.NOMBRE_ADMON);
                mapAdmon.Property(x => x.APELLIDO_ADMON);
                mapAdmon.Property(x => x.TELEFONO);
                mapAdmon.Property(x => x.DIRECCION);
                mapAdmon.Property(x => x.NICK_NAME);
                mapAdmon.Property(x => x.PASSWORD_ADMON);
                mapAdmon.ToTable("ADMINISTRADOR");
            }
        }
    }
}
