using PruebaAppApi.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainServices.Domain.Contracts.Product
{
    public interface IProductDomain
    {
        Task<List<Producto>> ConsultProducts();
        Task<DetalleProducto?> ConsultProductDetails(Guid IdProduct);
        Guid? AddDesiredProduct(ProductoDeseado productoDeseado);
        void DeleteDesiredProduct(Guid IdDesiredProduct);
        Task<List<ProductoDeseado>> ConsultDesiredProducts(Guid IdUser);
    }
}
