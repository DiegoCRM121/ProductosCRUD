using System;
using System.Collections.Generic;

namespace ProductosCRUD.Models;

public partial class Tiendas
{
    public int Tiendakey { get; set; }

    public int Geograficokey { get; set; }

    public string? Tipotienda { get; set; }

    public string? Nombretienda { get; set; }

    public int? Cantidadempleados { get; set; }

    public int? Tamañoarea { get; set; }
}
