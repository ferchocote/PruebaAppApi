using AplicationServices.DTOs.Category;
using AplicationServices.DTOs.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicationServices.Application.Contracts.Category
{
    public interface ICategoryServices
    {
        Task<RequestResult<List<ResponseQueryCategoriesDto>>> ConsultCategories();
    }
}
