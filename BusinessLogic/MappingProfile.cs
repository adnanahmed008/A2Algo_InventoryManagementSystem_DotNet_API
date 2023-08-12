using AutoMapper;
using Core.DTOs;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductReadDTO>().ReverseMap();

            CreateMap<ProductWriteDTO, Product>()
                .ForMember(dest => dest.Id, src => src.Ignore())
                .ForMember(dest => dest.Quantity, src => src.Ignore())
                .ForMember(dest => dest.Purchases, src => src.Ignore())
                .ForMember(dest => dest.Sales, src => src.Ignore())
                .ForMember(dest => dest.CreatedBy, src => src.Ignore())
                .ForMember(dest => dest.CreationDate, src => src.Ignore())
                .ForMember(dest => dest.ModifiedBy, src => src.Ignore())
                .ForMember(dest => dest.ModifiedDate, src => src.Ignore())
                .ForMember(dest => dest.IsDeleted, src => src.Ignore());



            CreateMap<Sale, SaleDTO>();
            CreateMap<Purchase, PurchaseDTO>();
            // Add more CreateMap calls for other entity-DTO pairs
        }
    }
}
