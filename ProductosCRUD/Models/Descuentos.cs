using System;
using System.Collections.Generic;

namespace ProductosCRUD.Models;

public partial class Descuentos
{
    public int Descuentokey { get; set; }

    public string? Etiqueta { get; set; }

    public string? Nombredescuento { get; set; }

    public decimal? Porcentaje { get; set; }

    public DateTime? Fechainicial { get; set; }

    public DateTime? Fechafinal { get; set; }
}
