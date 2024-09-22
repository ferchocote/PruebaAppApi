using System;
using System.Collections.Generic;

namespace PruebaAppApi.DataAccess.Entities;

public partial class Categoria
{
    public Guid IDCategoria { get; set; }

    public string Descripcion { get; set; } = null!;

    public string Codigo { get; set; } = null!;

    public bool Estado { get; set; }

    public virtual ICollection<Producto> Producto { get; } = new List<Producto>();
}
