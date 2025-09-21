using AutoMapper;
using Project.Application.Abstractions.Messaging;
using Project.Application.Abstractions.Repositories;
using Project.Application.Features.CartItems.Dtos;
using Project.Application.Features.Categories.Dtos;
using Project.Application.Features.Categories.Queries.GetById;
using Project.Domain.Models.CartItems;
using Project.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Features.CartItems.Queries.GetByd
{
    internal class GetItemByIdQueryHandler(IMapper mapper, IReadRepository<CartItem> CartItemRepository) : IQueryHandler<GetItemByIdQuery, CardItemDto>
    {
        public async Task<Response<CardItemDto>> Handle(GetItemByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await CartItemRepository.GetByIdAsync(request.Id, cancellationToken);
            if (product == null)
            {
                return Response<CardItemDto>.NotFound("CardItem not found");
            }

            var productDto = mapper.Map<CardItemDto>(product);
            return Response<CardItemDto>.Success(productDto);
        }
    }
}