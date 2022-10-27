using AutoMapper;
using DataAccess.Entites;
using DataAccess.Entities;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Config
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<UserDTO, User>();
            CreateMap<User, UserDTO>()
                .ForMember(dst => dst.RoleName, x => x.MapFrom(src => src.Role.Name));

            CreateMap<ProductDTO, Product>();
            CreateMap<Product, ProductDTO>();

            CreateMap<CartDTO, Cart>();            
            CreateMap<Cart, CartDTO>()
                .ForMember(dst => dst.ProductName,x=>x.MapFrom(src=>src.Product.Name))
                .ForMember(dst => dst.ProductImgPath,x=>x.MapFrom(src=>src.Product.ImgPath))
                .ForMember(dst => dst.ProductPrice,x=>x.MapFrom(src=>src.Product.Price));
        }
    }
}
