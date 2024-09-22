using AplicationServices.Application.Contracts.Helpers;
using AplicationServices.Application.Contracts.Product;
using AplicationServices.DTOs.Category;
using AplicationServices.DTOs.Generics;
using AplicationServices.DTOs.Product;
using AplicationServices.Helpers.TextResorce;
using AutoMapper;
using DomainServices.Domain.Contracts.Category;
using DomainServices.Domain.Contracts.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PruebaAppApi.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AplicationServices.Application.Product
{
    public class ProductAppServices : IProductServices
    {
        /// <summary>
        /// Instancia al servicio de Dominio
        /// </summary>
        private readonly IProductDomain _productDomain;
        private readonly ILoggerServices _loggerService;

        /// <summary>
        /// Mapper
        /// </summary>
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public ProductAppServices(IProductDomain productDomain, IConfiguration configuration, IMapper mapper, ILoggerServices loggerService)
        {
            _productDomain = productDomain;
            _configuration = configuration;
            _mapper = mapper;
            _loggerService = loggerService;
        }

        /// <summary>
        /// Consulta los productos activos
        /// </summary>
        /// <returns></returns>
        public async Task<RequestResult<List<ResponseQueryProductsDto>>> ConsultProducts()
        {
            try
            {

                var result = await _productDomain.ConsultProducts();
                
                string resultJson = JsonSerializer.Serialize(result);
                _loggerService.LogInfo(string.Concat("Acción ejecutada. ConsultProducts ", resultJson));

                return RequestResult<List<ResponseQueryProductsDto>>.CreateSuccessful(_mapper.Map<List<Producto>, List<ResponseQueryProductsDto>>(result));

            }
            catch (Exception ex)
            {
                _loggerService.LogError(string.Concat("Error ConsultProducts. ", ex.InnerException));
                return RequestResult<List<ResponseQueryProductsDto>>.CreateError(ex.Message);

            }
        }

        /// <summary>
        /// Consulta el detalle de un producto
        /// </summary>
        /// <returns></returns>
        public async Task<RequestResult<ResponseQueryProductDetailsDto>> ConsultProductDetails(Guid IdProduct)
        {
            try
            {
                #region Validaciones
                if (IdProduct == Guid.Empty)
                {
                    return RequestResult<ResponseQueryProductDetailsDto>.CreateUnsuccessful(null, new string[] { ResourceUserMsm.InvalidGuid });
                }
                #endregion

                var result = await _productDomain.ConsultProductDetails(IdProduct);

                string resultJson = JsonSerializer.Serialize(result);
                _loggerService.LogInfo(string.Concat("Acción ejecutada. ConsultProductDetails ", resultJson));

                if (result == null)
                {
                    return RequestResult<ResponseQueryProductDetailsDto>.CreateUnsuccessful(null, new string[] { ResourceUserMsm.InvalidProductDetails });
                }
                else
                {
                    return RequestResult<ResponseQueryProductDetailsDto>.CreateSuccessful(_mapper.Map<DetalleProducto, ResponseQueryProductDetailsDto>(result));
                }

            }
            catch (Exception ex)
            {
                _loggerService.LogError(string.Concat("Error ConsultProductDetails. ", ex.InnerException));
                return RequestResult<ResponseQueryProductDetailsDto>.CreateError(ex.Message);

            }
        }

        /// <summary>
        /// Agrega un producto deseado por usuario
        /// </summary>
        /// <returns></returns>
        public RequestResult<ResponseAddDesiredProductDto> AddDesiredProduct(RequestAddDesiredProductDto request)
        {
            try
            {
                ResponseAddDesiredProductDto responseAddDesiredProductDto = new ResponseAddDesiredProductDto();

                #region Validaciones
                if (request.IdProduct == Guid.Empty)
                {
                    return RequestResult<ResponseAddDesiredProductDto>.CreateUnsuccessful(null, new string[] { ResourceUserMsm.InvalidGuidProduct });
                }
                if (request.IdUser == Guid.Empty)
                {
                    return RequestResult<ResponseAddDesiredProductDto>.CreateUnsuccessful(null, new string[] { ResourceUserMsm.InvalidGuidUser });
                }
                #endregion

                ProductoDeseado productoDeseado = _mapper.Map<RequestAddDesiredProductDto, ProductoDeseado>(request);

                Guid? result =  _productDomain.AddDesiredProduct(productoDeseado);

                string resultJson = JsonSerializer.Serialize(result);
                _loggerService.LogInfo(string.Concat("Acción ejecutada. AddDesiredProduct ", resultJson));

                if (result == null)
                {
                    return RequestResult<ResponseAddDesiredProductDto>.CreateUnsuccessful(null, new string[] { ResourceUserMsm.ErrorAddingDesiredProduct });
                }
                else
                {
                    responseAddDesiredProductDto.IdDesaireProduct = result.Value;
                    return RequestResult<ResponseAddDesiredProductDto>.CreateSuccessful(responseAddDesiredProductDto);
                }

            }
            catch (Exception ex)
            {
                _loggerService.LogError(string.Concat("Error AddDesiredProduct. ", ex.InnerException));
                return RequestResult<ResponseAddDesiredProductDto>.CreateError(ex.Message);

            }
        }

        /// <summary>
        /// Elimina un producto deseado
        /// </summary>
        /// <returns></returns>
        public RequestResult<bool> DeleteDesiredProduct(Guid IDDesiredProduct)
        {
            try
            {
                #region Validaciones
                if (IDDesiredProduct == Guid.Empty)
                {
                    return RequestResult<bool>.CreateUnsuccessful(false, new string[] { ResourceUserMsm.InvalidGuid });
                }
                #endregion

                _productDomain.DeleteDesiredProduct(IDDesiredProduct);

                _loggerService.LogInfo(string.Concat("Acción ejecutada. DeleteDesiredProduct ", IDDesiredProduct.ToString()));

                return RequestResult<bool>.CreateSuccessful(true);

            }
            catch (Exception ex)
            {
                _loggerService.LogError(string.Concat("Error DeleteDesiredProduct. ", ex.InnerException));
                return RequestResult<bool>.CreateError(ex.Message);

            }
        }

        /// <summary>
        /// Consulta los productos deseados de un usuario
        /// </summary>
        /// <returns></returns>
        public async Task<RequestResult<List<ResponseQueryDesiredProductsDto>>> ConsultDesiredProducts(Guid IDUser)
        {
            try
            {
                #region Validaciones
                if (IDUser == Guid.Empty)
                {
                    return RequestResult<List<ResponseQueryDesiredProductsDto>>.CreateUnsuccessful(null, new string[] { ResourceUserMsm.InvalidGuid });
                }
                #endregion

                var result = await _productDomain.ConsultDesiredProducts(IDUser);

                string resultJson = JsonSerializer.Serialize(result);
                _loggerService.LogInfo(string.Concat("Acción ejecutada. ConsultDesiredProducts ", resultJson));

                if (result == null)
                {
                    return RequestResult<List<ResponseQueryDesiredProductsDto>>.CreateUnsuccessful(null, new string[] { ResourceUserMsm.NoRecordsFound });
                }
                else
                {
                    return RequestResult<List<ResponseQueryDesiredProductsDto>>.CreateSuccessful(_mapper.Map<List<ProductoDeseado>, List<ResponseQueryDesiredProductsDto>>(result));
                }

            }
            catch (Exception ex)
            {
                _loggerService.LogError(string.Concat("Error ConsultDesiredProducts. ", ex.InnerException));
                return RequestResult<List<ResponseQueryDesiredProductsDto>>.CreateError(ex.Message);

            }
        }
    }
}
