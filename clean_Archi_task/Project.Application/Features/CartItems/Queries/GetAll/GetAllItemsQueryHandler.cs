using AutoMapper;
using Project.Application.Abstractions.Messaging;
using Project.Application.Abstractions.Repositories;
using Project.Application.Features.CartItems.Dtos;
using Project.Application.Features.CartItems.Specifications;
using Project.Application.Features.Categories.Dtos;
using Project.Application.Features.Categories.Queries.GetAll;
using Project.Application.Features.Categories.Specifications;
using Project.Domain.Models.CartItems;
using Project.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Features.CartItems.Queries.GetAll
{
    public class GetAllItemsQueryHandler(IMapper mapper, IReadRepository<CartItem> cardItemRepository) : IQueryHandler<GetAllItemsQuery, PaginatedResult<CardItemDto>>
    {
        public async Task<Response<PaginatedResult<CardItemDto>>> Handle(GetAllItemsQuery request, CancellationToken cancellationToken)
        {
            var products = await cardItemRepository
                .ListAsync(new CartItemSpec(request.Name,
                    request.PageSize,
                    request.PageNumber), cancellationToken);

            var productsCount = await cardItemRepository
                .CountAsync(new CartItemSpec(request.Name,
                    request.PageSize,
                    request.PageNumber), cancellationToken);

            var mappedProducts = mapper.Map<IEnumerable<CardItemDto>>(products);

            return Response<CardItemDto>.GetData(mappedProducts, request.PageNumber, request.PageSize, productsCount);
        }
    }
}
