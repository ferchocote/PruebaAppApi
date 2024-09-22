using System;
using System.Collections.Generic;

namespace PruebaAppApi.DataAccess.Entities;

public partial class Usuario
{
    public Guid IDUsuario { get; set; }

    public string PrimerNombre { get; set; } = null!;

    public string? SegundoNombre { get; set; }

    public string PrimerApellido { get; set; } = null!;

    public string SegundoApellido { get; set; } = null!;

    public string NumeroDocumento { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Dirección { get; set; } = null!;

    public bool? Estado { get; set; }

    public virtual ICollection<ProductoDeseado> ProductoDeseado { get; } = new List<ProductoDeseado>();
}
