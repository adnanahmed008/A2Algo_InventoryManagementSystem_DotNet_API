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
            CreateMap<Product, ProductNomenclatureDTO>();
            CreateMap<Product, ProductReadDTO>().ReverseMap();
            CreateMap<ProductWriteDTO, Product>();

            CreateMap<Sale, SaleReadDTO>().ReverseMap();

            CreateMap<Purchase, PurchaseReadDTO>().ReverseMap();
        }
    }
}
