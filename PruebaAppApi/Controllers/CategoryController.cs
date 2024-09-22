using AplicationServices.Application.Contracts.Category;
using AplicationServices.DTOs.Category;
using AplicationServices.DTOs.Generics;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace PruebaAppApi.Controllers
{
    [ApiController]
    [Route("Api/Category")]
    public class CategoryController
    {
        /// <summary>
        /// Instancia al servicio de aplicación
        /// </summary>
        private readonly ICategoryServices _CategoryServices;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryServices ICategoryServices, IMapper mapper)
        {

            _CategoryServices = ICategoryServices;
            _mapper = mapper;
        }

        /// <summary>
        /// Consulta las categorias activas
        /// </summary>
        /// <returns></returns>
        [HttpGet("ConsultCategories")]
        public async Task<RequestResult<List<ResponseQueryCategoriesDto>>> ConsultCategories()
        {
            return await _CategoryServices.ConsultCategories();
        }
    }
}
