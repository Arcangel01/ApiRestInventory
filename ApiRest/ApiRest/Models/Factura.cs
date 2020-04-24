using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRest.Models
{
    public class Factura
    {

        public int ID_F_VENTA { get; set; }
        public string DOCUMENTO_C { get; set; }
        public string NOMBRE_C { get; set; }
        public string APELLIDO_C { get; set; }
        public string TELEFONO_C { get; set; }
        public string FECHA { get; set; }
        public int ID_PRODUCTO { get; set; }
        public int CANTIDAD { get; set; }
        public Decimal PRECIO { get; set; }
        public Decimal SUBTOTAL { get; set; }
        public Decimal TOTAL { get; set; }

        public Productos Productos { get; set; }

        public class MapeoFact
        {
            public MapeoFact(EntityTypeBuilder<Factura> mapFact)
            {
                mapFact.HasKey(x => x.ID_F_VENTA);
                mapFact.Property(x => x.DOCUMENTO_C);
                mapFact.Property(x => x.NOMBRE_C);
                mapFact.Property(x => x.APELLIDO_C);
                mapFact.Property(x => x.TELEFONO_C);
                mapFact.Property(x => x.FECHA);
                mapFact.Property(x => x.ID_PRODUCTO);
                mapFact.Property(x => x.PRECIO);
                mapFact.Property(x => x.SUBTOTAL);
                mapFact.Property(x => x.TOTAL);
                mapFact.ToTable("F_VENTA");
                mapFact.HasOne(x => x.Productos);
            }
        }
    }
}
