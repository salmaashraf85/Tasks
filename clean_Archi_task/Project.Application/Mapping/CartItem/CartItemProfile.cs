using AutoMapper;
using Project.Application.Features.CartItems.Commands.Add;
using Project.Application.Features.CartItems.Commands.Delete;
using Project.Application.Features.CartItems.Commands.Update;
using Project.Application.Features.CartItems.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Mapping.CartItem
{
    public class CartItemProfile : Profile
    {
        public CartItemProfile()
        {
            CreateMap<AddCartItemCommand, Domain.Models.CartItems.CartItem>();
            CreateMap<DeleteCardItemCommand, Domain.Models.CartItems.CartItem>();
            CreateMap<UpdateCardItemCommand, Domain.Models.CartItems.CartItem>();
            CreateMap<CardItemDto, Domain.Models.CartItems.CartItem>().ReverseMap();
        }
    }
}