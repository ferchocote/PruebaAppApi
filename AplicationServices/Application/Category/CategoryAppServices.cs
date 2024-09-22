using AplicationServices.Application.Contracts.Category;
using AplicationServices.Application.Contracts.Helpers;
using AplicationServices.DTOs.Category;
using AplicationServices.DTOs.Generics;
using AplicationServices.Helpers.TextResorce;
using AutoMapper;
using DomainServices.Domain.Contracts.Category;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PruebaAppApi.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AplicationServices.Application.Category
{
    public class CategoryAppServices : ICategoryServices
    {
        /// <summary>
        /// Instancia al servicio de Dominio
        /// </summary>
        private readonly ICategoryDomain _categoryDomain;
        private readonly ILoggerServices _loggerService;

        /// <summary>
        /// Mapper
        /// </summary>
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public CategoryAppServices(ICategoryDomain categoryDomain, IConfiguration configuration, IMapper mapper, ILoggerServices loggerService)
        {
            _categoryDomain = categoryDomain;
            _configuration = configuration;
            _mapper = mapper;
            _loggerService = loggerService;
        }

        /// <summary>
        /// Consulta las categorias activas
        /// </summary>
        /// <returns></returns>
        public async Task<RequestResult<List<ResponseQueryCategoriesDto>>> ConsultCategories()
        {
            try
            {
                var result =  await _categoryDomain.ConsultCategories();

                string resultJson = JsonSerializer.Serialize(result);
                _loggerService.LogInfo(string.Concat("Acción ejecutada. ConsultCategories ", resultJson));

                return RequestResult<List<ResponseQueryCategoriesDto>>.CreateSuccessful(_mapper.Map<List<Categoria>, List<ResponseQueryCategoriesDto>>(result));

            }
            catch (Exception ex)
            {
                string exJson = JsonSerializer.Serialize(ex);
                _loggerService.LogError(string.Concat("Error ConsultCategories. ", exJson));
                return RequestResult<List<ResponseQueryCategoriesDto>>.CreateError(ex.Message);

            }
        }
    }
}
