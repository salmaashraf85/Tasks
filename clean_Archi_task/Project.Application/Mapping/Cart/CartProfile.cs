using AutoMapper;
using Project.Application.Features.Carts.Commands.Add;
using Project.Application.Features.Carts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Mapping.Cart
{
    internal class CartProfile : Profile
    {
        public CartProfile()
        {
            CreateMap<AddCartCommand, Domain.Models.Carts.Cart>();
            CreateMap<Domain.Models.Carts.Cart,CardDto>();
        }
    }
}