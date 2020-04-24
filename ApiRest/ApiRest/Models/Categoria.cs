using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRest.Models
{
    public class Categoria
    {
        public int ID_CATEGORIA { get; set; }
        public string NOMBRE_CATEGORIA { get; set; }

        public class MapeoCat
        {
            public MapeoCat(EntityTypeBuilder<Categoria> mapCat)
            {
                mapCat.HasKey(x => x.ID_CATEGORIA);
                mapCat.Property(x => x.NOMBRE_CATEGORIA);
                mapCat.ToTable("CATEGORIA");
            }
        }
    }
}
