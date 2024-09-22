using PruebaAppApi.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainServices.Domain.Contracts.Category
{
    public interface ICategoryDomain
    {
        Task<List<Categoria>> ConsultCategories();
    }
}
