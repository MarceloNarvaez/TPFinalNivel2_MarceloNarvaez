using Google.Type;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Decimal = System.Decimal;

namespace dominio
{
    public class Articulos
    {
        

        public int Id { get; set; }
        [DisplayName("Codigo")]
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        [DisplayName("Descripcion")]
        public string Descripcion { get; set; }
        public Marcas Marca { get; set; }
        public Categorias Categoria { get; set; }
        public string ImagenUrl { get; set; }
        public Decimal Precio { get; set; }

        

    }
}
