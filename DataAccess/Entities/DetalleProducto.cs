using System;
using System.Collections.Generic;

namespace PruebaAppApi.DataAccess.Entities;

public partial class DetalleProducto
{
    public Guid IDDetalleProducto { get; set; }

    public Guid IDProducto { get; set; }

    public decimal Precio { get; set; }

    public int Stock { get; set; }

    public string? Color { get; set; }

    public string? Talla { get; set; }

    public virtual Producto IDProductoNavigation { get; set; } = null!;
}
