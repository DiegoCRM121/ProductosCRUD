using ProductosCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductosCRUD.DTOs
{
    public class ProductosSubCategoriasDTO
    {
        public int Productokey { get; set; }

        public string? Nombre { get; set; }

        public string? Descripción { get; set; }

        public string? Subcategoria { get; set; }
    }
}
