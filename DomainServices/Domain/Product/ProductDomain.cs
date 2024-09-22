using DomainServices.Domain.Contracts.Category;
using DomainServices.Domain.Contracts.Product;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PruebaAppApi.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainServices.Domain.Product
{
    public class ProductDomain : IProductDomain
    {
        private readonly PruebaTiendaContext _context;
        public ProductDomain(PruebaTiendaContext pruebaApiContext)
        {
            _context = pruebaApiContext;
        }

        /// <summary>
        /// Consulta los productos activos
        /// </summary>
        /// <returns></returns>
        public async Task<List<Producto>> ConsultProducts()
        {
            return await _context.Producto.Where(i => i.Estado == true).AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// Consulta el detalle de un producto
        /// </summary>
        /// <returns></returns>
        public async Task<DetalleProducto?> ConsultProductDetails(Guid IdProduct)
        {
            return await _context.DetalleProducto.Where(i => i.IDProducto.Equals(IdProduct)).AsNoTracking().FirstOrDefaultAsync();
        }

        /// <summary>
        /// Agrega un producto deseado por usuario
        /// </summary>
        /// <returns></returns>
        public Guid? AddDesiredProduct(ProductoDeseado productoDeseado)
        {
            Guid? IDProductoDeseado = null;
            
            var productoDeseadoGrabado = _context.ProductoDeseado.Where(i => i.IDProducto.Equals(productoDeseado.IDProducto) && i.IDProducto.Equals(productoDeseado.IDProducto)).FirstOrDefault();

            if (productoDeseadoGrabado != null)
            {
                IDProductoDeseado = productoDeseadoGrabado.IDProductoDeseado;
                if (!productoDeseadoGrabado.Estado)
                {
                    productoDeseadoGrabado.Estado = true;
                    _context.SaveChanges();
                }
            }

            if (IDProductoDeseado == null)
            {
                productoDeseado.IDProductoDeseado = Guid.NewGuid();
                _context.ProductoDeseado.Add(productoDeseado);
                _context.SaveChanges();
                IDProductoDeseado = productoDeseado.IDProductoDeseado;
            }    

            return IDProductoDeseado;
        }

        /// <summary>
        /// Elimina un producto deseado
        /// </summary>
        /// <returns></returns>
        public void DeleteDesiredProduct(Guid IdDesiredProduct)
        {

            var productoDeseadoGrabado = _context.ProductoDeseado.Where(i => i.IDProductoDeseado.Equals(IdDesiredProduct))?.FirstOrDefault();

            if (productoDeseadoGrabado != null)
            {
                if (productoDeseadoGrabado.Estado)
                {
                    productoDeseadoGrabado.Estado = false;
                    _context.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Consulta los productos deseados de un usuario
        /// </summary>
        /// <returns></returns>
        public async Task<List<ProductoDeseado>> ConsultDesiredProducts(Guid IdUser)
        {
            return await _context.ProductoDeseado.Include(x => x.IDProductoNavigation).Where(i => i.IDUsuario.Equals(IdUser) && i.Estado && i.IDProductoNavigation.Estado).AsNoTracking().ToListAsync();
        }
    }
}
