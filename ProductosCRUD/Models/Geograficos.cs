using System;
using System.Collections.Generic;

namespace ProductosCRUD.Models;

public partial class Geograficos
{
    public int Geograficokey { get; set; }

    public string? Continente { get; set; }

    public string? Pais { get; set; }
}
