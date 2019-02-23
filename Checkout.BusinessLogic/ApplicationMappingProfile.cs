using AutoMapper;

namespace Checkout.BusinessLogic
{
    using Cart;
    using Extensions;
    using Inventory;
    using Location;
    using Models;

    public class ApplicationMappingProfile : Profile
    {
        public ApplicationMappingProfile()
        {
            CreateMaps<CountryEntity, Country>();
            CreateMaps<ProductEntity, Product>();
            CreateCartMapping();
        }

        /// <summary>
        /// Creates a two way automap configuration.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TDestination"></typeparam>
        /// <returns></returns>
        void CreateMaps<TSource, TDestination>()
        where TSource : class
        where TDestination : class
        {
            CreateMap<TSource, TDestination>();
            CreateMap<TDestination, TSource>();
        }

        /// <summary>
        /// Cart special projection mapping.
        /// </summary>
        public void CreateCartMapping()
        {
            CreateMaps<CartEntity, Cart>();
            CreateMaps<CartEntity, CartItem>();
            CreateMap<CartProduct, CartEntity>();

            //Custom CartProduct map (A Dto describing cart "product" logic)
            CreateMap<CartEntity, CartProduct>()
                .ForMember(dest => dest.CountryIsoCode, opt => opt.MapFrom(src => src.Country.IsoCode))
                .ForMember(dest => dest.ProductCode, opt => opt.MapFrom(src => src.Product.Code))
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name))
                .ForMember(dest => dest.NetPrice, opt => opt.MapFrom(src => src.Product.NetPrice))
                .ForMember(dest => dest.TaxAmount, opt => opt.MapFrom(src => src.Product.NetPrice.AsTaxAmount(src.Country.Tax)));
        }
    }
}