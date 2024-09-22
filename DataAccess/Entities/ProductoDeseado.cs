using System;
using System.Collections.Generic;

namespace PruebaAppApi.DataAccess.Entities;

public partial class ProductoDeseado
{
    public Guid IDProductoDeseado { get; set; }

    public Guid IDUsuario { get; set; }

    public Guid IDProducto { get; set; }

    public bool Estado { get; set; }

    public virtual Producto IDProductoNavigation { get; set; } = null!;

    public virtual Usuario IDUsuarioNavigation { get; set; } = null!;
}
