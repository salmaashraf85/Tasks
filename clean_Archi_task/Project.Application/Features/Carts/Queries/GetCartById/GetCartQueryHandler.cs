using AutoMapper;
using Project.Application.Abstractions.Messaging;
using Project.Application.Abstractions.Repositories;
using Project.Application.Features.Carts.Dtos;
using Project.Domain.Models.Carts;
using Project.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Application.Features.Carts.Specification;

namespace Project.Application.Features.Carts.Queries.GetCartById
{
    internal class GetCartQueryHandler(IMapper mapper, IReadRepository<Cart> CartRepository) : IQueryHandler<GetCartQuery, CardDto>
    {
        public async Task<Response<CardDto>> Handle(GetCartQuery request, CancellationToken cancellationToken)
        {
            var cart = await CartRepository.FirstOrDefaultAsync(new CartwithItemSpec(request.Id),cancellationToken);
            if (cart == null)
            {
                return Response<CardDto>.NotFound("Card not found");
            }

            var productDto = mapper.Map<CardDto>(cart);
            return Response<CardDto>.Success(productDto);
        }
    }
}