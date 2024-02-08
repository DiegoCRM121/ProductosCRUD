using System;
using System.Collections.Generic;

namespace ProductosCRUD.Models;

public partial class Ventas
{
    public int Ordenid { get; set; }

    public DateTime? Fechakey { get; set; }

    public int? Tipokey { get; set; }

    public int? Tiendakey { get; set; }

    public int? Productokey { get; set; }

    public int? Descuentokey { get; set; }

    public int? Cantidadvendida { get; set; }

    public int? Cantidaddevoluciones { get; set; }
}
