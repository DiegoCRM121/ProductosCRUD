using System;
using System.Collections.Generic;

namespace ProductosCRUD.Models;

public partial class Productos
{
    public int Productokey { get; set; }

    public string? Nombre { get; set; }

    public string? Descripción { get; set; }

    public int? Subcategoriakey { get; set; }

    public string? Manufactura { get; set; }

    public string? Marca { get; set; }

    public int? Claseid { get; set; }

    public string? Nombreclase { get; set; }

    public int? Coloid { get; set; }

    public string? Color { get; set; }

    public string? Medida { get; set; }

    public decimal? Tamaño { get; set; }

    public decimal? Costo { get; set; }

    public decimal? Precio { get; set; }
}
