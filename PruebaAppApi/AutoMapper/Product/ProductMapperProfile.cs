using AplicationServices.DTOs.Category;
using AplicationServices.DTOs.Product;
using AutoMapper;
using PruebaAppApi.DataAccess.Entities;

namespace PruebaAppApi.AutoMapper.Product
{
    public class ProductMapperProfile : Profile
    {
        public ProductMapperProfile()
        {
            FromProductotoResponseQueryProductsDto();
            FromProductotoResponseQueryProductDetailsDto();
            FromRequestAddDesiredProductDtotoProductoDeseado();
            FromProductoDeseadotoResponseQueryDesiredProductsDto();
        }

        /// <summary>
        /// convierte desde Producto hasta ResponseQueryProductsDto
        /// </summary>
        private void FromProductotoResponseQueryProductsDto()
        {
            CreateMap<Producto, ResponseQueryProductsDto>()
                .ForMember(target => target.IdProduct, opt => opt.MapFrom(source => source.IDProducto))
                .ForMember(target => target.Description, opt => opt.MapFrom(source => source.Descripcion))
                .ForMember(target => target.Code, opt => opt.MapFrom(source => source.Codigo))
                .ForMember(target => target.State, opt => opt.MapFrom(source => source.Estado))
                .ReverseMap();

        }

        /// <summary>
        /// convierte desde DetalleProducto hasta ResponseQueryProductDetailsDto
        /// </summary>
        private void FromProductotoResponseQueryProductDetailsDto()
        {
            CreateMap<DetalleProducto, ResponseQueryProductDetailsDto>()
                .ForMember(target => target.IdProduct, opt => opt.MapFrom(source => source.IDProducto))
                .ForMember(target => target.IdProductDetail, opt => opt.MapFrom(source => source.IDDetalleProducto))
                .ForMember(target => target.Price, opt => opt.MapFrom(source => source.Precio))
                .ForMember(target => target.Stock, opt => opt.MapFrom(source => source.Stock))
                .ForMember(target => target.Color, opt => opt.MapFrom(source => source.Color))
                .ForMember(target => target.Size, opt => opt.MapFrom(source => source.Talla))
                .ReverseMap();

        }

        /// <summary>
        /// convierte desde RequestAddDesiredProductDto hasta ProductoDeseado
        /// </summary>
        private void FromRequestAddDesiredProductDtotoProductoDeseado()
        {
            CreateMap<RequestAddDesiredProductDto, ProductoDeseado>()
                .ForMember(target => target.IDProducto, opt => opt.MapFrom(source => source.IdProduct))
                .ForMember(target => target.IDUsuario, opt => opt.MapFrom(source => source.IdUser))
                .ForMember(target => target.Estado, opt => opt.MapFrom(source => true))
                .ReverseMap();

        }

        /// <summary>
        /// convierte desde ResponseQueryDesiredProductsDto hasta ProductoDeseado
        /// </summary>
        private void FromProductoDeseadotoResponseQueryDesiredProductsDto()
        {
            CreateMap<ProductoDeseado, ResponseQueryDesiredProductsDto> ()
                .ForMember(target => target.IdDesiredProduct, opt => opt.MapFrom(source => source.IDProductoDeseado))
                .ForMember(target => target.IdProduct, opt => opt.MapFrom(source => source.IDProducto))
                .ForMember(target => target.Description, opt => opt.MapFrom(source => source.IDProductoNavigation.Descripcion))
                .ForMember(target => target.Code, opt => opt.MapFrom(source => source.IDProductoNavigation.Codigo))
                .ForMember(target => target.State, opt => opt.MapFrom(source => source.IDProductoNavigation.Estado))
                .ReverseMap();

        }
    }

}
