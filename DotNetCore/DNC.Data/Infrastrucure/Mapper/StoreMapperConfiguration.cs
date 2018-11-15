using AutoMapper;
using DNC.Core.Domain.Store;
using DNC.Core.Domain.Walmart.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace DNC.Data.Infrastrucure.Mapper
{
    public class StoreMapperConfiguration : Profile
    {
        #region Ctor
        public StoreMapperConfiguration()
        {
            //create specific maps
            CreateProductsMaps();
            CreateRecommendationsMaps();
            CreateSearchProductsMaps();
            CreateSearchMaps();
        }

        #endregion

        #region Utilities

        /// <summary>
        /// Create Product/Item maps 
        /// </summary>
        protected virtual void CreateProductsMaps()
        {
            CreateMap<Item, Product>()
                .ForMember(dest => dest.ProductId, opts => opts.MapFrom(src => src.itemId))
                .ForMember(dest => dest.ProductName, opts => opts.MapFrom(src => src.name))
                .ForMember(dest => dest.Price, opts => opts.MapFrom(src => src.salePrice))
                .ForMember(dest => dest.ShortDescription, opts => opts.MapFrom(src => src.shortDescription))
                .ForMember(dest => dest.ThumbnailUri, opts => opts.MapFrom(src => src.thumbnailImage));

            CreateMap<Product, Item>()
                .ForMember(dest => dest.itemId, opts => opts.MapFrom(src => src.ProductId))
                .ForMember(dest => dest.name, opts => opts.MapFrom(src => src.ProductName))
                .ForMember(dest => dest.salePrice, opts => opts.MapFrom(src => src.Price))
                .ForMember(dest => dest.shortDescription, opts => opts.MapFrom(src => src.ShortDescription))
                .ForMember(dest => dest.thumbnailImage, opts => opts.MapFrom(src => src.ThumbnailUri));
        }

        /// <summary>
        /// Create Recommendation/ItemRecommendation maps 
        /// </summary>
        protected virtual void CreateRecommendationsMaps()
        {
            CreateMap<ItemRecommendation, Recommendation>()
                .ForMember(dest => dest.ProductId, opts => opts.MapFrom(src => src.itemId))
                .ForPath(dest => dest.Product.ProductName, opts => opts.MapFrom(src => src.name))
                .ForPath(dest => dest.Product.Price, opts => opts.MapFrom(src => src.salePrice))
                .ForPath(dest => dest.Product.ShortDescription, opts => opts.MapFrom(src => src.shortDescription))
                .ForPath(dest => dest.Product.ThumbnailUri, opts => opts.MapFrom(src => src.thumbnailImage))
                .ForMember(dest => dest.OfferType, opts => opts.MapFrom(src => src.offerType))
                .ForMember(dest => dest.IsTwoDayShippingEligible, opts => opts.MapFrom(src => src.isTwoDayShippingEligible))
                .ReverseMap();

        }

        /// <summary>
        /// Create Search products maps 
        /// </summary>
        protected virtual void CreateSearchProductsMaps()
        {
            CreateMap<Item, SearchProduct>()
                .ForMember(dest => dest.ProductId, opts => opts.MapFrom(src => src.itemId))
                .ForPath(dest => dest.Product.ProductName, opts => opts.MapFrom(src => src.name))
                .ForPath(dest => dest.Product.Price, opts => opts.MapFrom(src => src.salePrice))
                .ForPath(dest => dest.Product.ShortDescription, opts => opts.MapFrom(src => src.shortDescription))
                .ForPath(dest => dest.Product.ThumbnailUri, opts => opts.MapFrom(src => src.thumbnailImage))
                .ReverseMap();

        }

        /// <summary>
        /// Create Search maps 
        /// </summary>
        protected virtual void CreateSearchMaps()
        {
            CreateMap<ItemSearch, SearchResult>()
                .ForMember(dest => dest.SearchTerm, opts => opts.MapFrom(src => src.query))
                .ForMember(dest => dest.SortOrder, opts => opts.MapFrom(src => src.sort))
                .ForMember(dest => dest.TotalResult, opts => opts.MapFrom(src => src.totalResults))
                .ForMember(dest => dest.Index, opts => opts.MapFrom(src => src.start))
                .ForMember(dest => dest.ResultSize, opts => opts.MapFrom(src => src.numItems))
                //.IncludeBase<Item, SearchProduct>()
                .ForMember(dest => dest.SearchProducts, opts => opts.MapFrom(src => src.items))
                .ReverseMap();

        }

        #endregion

    }
}
