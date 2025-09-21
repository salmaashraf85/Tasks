using AutoMapper;
using Project.Application.Abstractions.Messaging;
using Project.Application.Abstractions.Repositories;
using Project.Application.Features.Categories.Commands.Add;
using Project.Domain.Models.CartItems;
using Project.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Features.CartItems.Commands.Add
{
    internal class AddCartItemCommandHandler(IMapper mapper, IRepository<CartItem> cardItemRepository) : ICommandHandler<AddCartItemCommand, Guid>
    {
        public async Task<Response<Guid>> Handle(AddCartItemCommand request, CancellationToken cancellationToken)
        {
            var cartItem = mapper.Map<CartItem>(request);
            await cardItemRepository.AddAsync(cartItem, cancellationToken);
            return Response<Guid>.Created(cartItem.Id);
        }
    }
}