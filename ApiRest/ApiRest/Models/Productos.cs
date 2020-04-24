using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRest.Models
{
    public class Productos
    {
        public int ID_PRODUCTO { get; set;}
        public string CODIGO_PRODUCTO { get; set; }
        public string NOMBRE_PRODUCTO { get; set; }
        public string DESCRIPCION { get; set; }
        public string IMAGEN_PROD { get; set; }
        public int CANTIDAD_PRODUCTO { get; set; }
        public Decimal PRECIO_UNIDAD { get; set; }
        public int ID_CATEGORIA { get; set; }

        public Categoria Categoria { get; set; }

        public class MapeoProd
        {
            public MapeoProd(EntityTypeBuilder<Productos> mapProd)
            {
                mapProd.HasKey(x => x.ID_PRODUCTO);
                mapProd.Property(x => x.CODIGO_PRODUCTO);
                mapProd.Property(x => x.NOMBRE_PRODUCTO);
                mapProd.Property(x => x.DESCRIPCION);
                mapProd.Property(x => x.IMAGEN_PROD);
                mapProd.Property(x => x.CANTIDAD_PRODUCTO);
                mapProd.Property(x => x.PRECIO_UNIDAD);
                mapProd.Property(x => x.ID_CATEGORIA);
                mapProd.ToTable("PRODUCTO");
                mapProd.HasOne(x => x.Categoria);
            }
        }
    }
}
