using AplicationServices.Application.Contracts.Category;
using AplicationServices.Application.Contracts.Product;
using AplicationServices.DTOs.Category;
using AplicationServices.DTOs.Generics;
using AplicationServices.DTOs.Product;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace PruebaAppApi.Controllers
{
    [ApiController]
    [Route("Api/Category")]
    public class ProductController
    {
        /// <summary>
        /// Instancia al servicio de aplicación
        /// </summary>
        private readonly IProductServices _productServices;
        private readonly IMapper _mapper;

        public ProductController(IProductServices productServices, IMapper mapper)
        {

            _productServices = productServices;
            _mapper = mapper;
        }


        /// <summary>
        /// Consulta los productos activos
        /// </summary>
        /// <returns></returns>
        [HttpGet("ConsultProducts")]
        public async Task<RequestResult<List<ResponseQueryProductsDto>>> ConsultProducts()
        {
            return await _productServices.ConsultProducts();
        }

        /// <summary>
        /// Consulta el detalle de un producto
        /// </summary>
        /// <returns></returns>
        [HttpGet("ConsultProductDetails")]
        public async Task<RequestResult<ResponseQueryProductDetailsDto>> ConsultProductDetails(Guid IDProduct)
        {
            return await _productServices.ConsultProductDetails(IDProduct);
        }

        /// <summary>
        /// Agrega un producto deseado por usuario
        /// </summary>
        /// <returns></returns>
        [HttpPost("AddDesiredProduct")]
        public RequestResult<ResponseAddDesiredProductDto> AddDesiredProduct(RequestAddDesiredProductDto request)
        {
            return _productServices.AddDesiredProduct(request);
        }

        /// <summary>
        /// Elimina un producto deseado
        /// </summary>
        /// <returns></returns>
        [HttpPost("DeleteDesiredProduct")]
        public RequestResult<bool> DeleteDesiredProduct(Guid IDDesiredProduct)
        {
            return _productServices.DeleteDesiredProduct(IDDesiredProduct);
        }

        /// <summary>
        /// Consulta los productos deseados de un usuario
        /// </summary>
        /// <returns></returns>
        [HttpGet("ConsultDesiredProducts")]
        public async Task<RequestResult<List<ResponseQueryDesiredProductsDto>>> ConsultDesiredProducts(Guid IDUser)
        {
            return await _productServices.ConsultDesiredProducts(IDUser);
        }
    }
}
