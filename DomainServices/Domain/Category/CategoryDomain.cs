using DomainServices.Domain.Contracts.Category;
using Microsoft.EntityFrameworkCore;
using PruebaAppApi.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainServices.Domain.Category
{
    public class CategoryDomain : ICategoryDomain
    {
        private readonly PruebaTiendaContext _context;
        public CategoryDomain(PruebaTiendaContext pruebaApiContext)
        {
            _context = pruebaApiContext;
        }

        /// <summary>
        /// Consulta las categorias activas
        /// </summary>
        /// <returns></returns>
        public async Task<List<Categoria>> ConsultCategories()
        {
            return await _context.Categoria.Where(i => i.Estado == true).AsNoTracking().ToListAsync();

        }

    }
}
