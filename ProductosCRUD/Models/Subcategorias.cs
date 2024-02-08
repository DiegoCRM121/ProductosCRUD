using System;
using System.Collections.Generic;

namespace ProductosCRUD.Models;

public partial class Subcategorias
{
    public int Subcategoriakey { get; set; }

    public string? Subcategoria { get; set; }

    public int? Categoriakey { get; set; }
}
