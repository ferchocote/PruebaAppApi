using AplicationServices.DTOs.Category;
using AutoMapper;
using PruebaAppApi.DataAccess.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace PruebaAppApi.AutoMapper.Category
{
    public class CategoryMapperProfile : Profile
    {
        public CategoryMapperProfile()
        {
            FromCategoriatoResponseQueryCategoriesDto();
        }
        /// <summary>
        /// convierte desde categoria hasta ResponseQueryCategoriesDto
        /// </summary>
        private void FromCategoriatoResponseQueryCategoriesDto()
        {
            CreateMap<Categoria, ResponseQueryCategoriesDto>()
                .ForMember(target => target.IdCategory, opt => opt.MapFrom(source => source.IDCategoria))
                .ForMember(target => target.Description, opt => opt.MapFrom(source => source.Descripcion))
                .ForMember(target => target.Code, opt => opt.MapFrom(source => source.Codigo))
                .ForMember(target => target.State, opt => opt.MapFrom(source => source.Estado))
                .ReverseMap();

        }

    }
}
