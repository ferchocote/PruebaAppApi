using AplicationServices.DTOs.Category;
using AplicationServices.DTOs.Generics;
using AplicationServices.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicationServices.Application.Contracts.Product
{
    public interface IProductServices
    {
        Task<RequestResult<List<ResponseQueryProductsDto>>> ConsultProducts();
        Task<RequestResult<ResponseQueryProductDetailsDto>> ConsultProductDetails(Guid IDProduct);
        RequestResult<ResponseAddDesiredProductDto> AddDesiredProduct(RequestAddDesiredProductDto request);
        RequestResult<bool> DeleteDesiredProduct(Guid IDDesiredProduct);
        Task<RequestResult<List<ResponseQueryDesiredProductsDto>>> ConsultDesiredProducts(Guid IDUser);
    }
}
