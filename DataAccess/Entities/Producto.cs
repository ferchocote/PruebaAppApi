using System;
using System.Collections.Generic;

namespace PruebaAppApi.DataAccess.Entities;

public partial class Producto
{
    public Guid IDProducto { get; set; }

    public Guid IDCategoria { get; set; }

    public string Descripcion { get; set; } = null!;

    public string Codigo { get; set; } = null!;

    public bool Estado { get; set; }

    public virtual ICollection<DetalleProducto> DetalleProducto { get; } = new List<DetalleProducto>();

    public virtual Categoria IDCategoriaNavigation { get; set; } = null!;

    public virtual ICollection<ProductoDeseado> ProductoDeseado { get; } = new List<ProductoDeseado>();
}
