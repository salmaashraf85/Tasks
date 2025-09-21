using AutoMapper;
using Project.Application.Abstractions.Messaging;
using Project.Application.Abstractions.Repositories;
using Project.Application.Features.CartItems.Commands.Delete;
using Project.Domain.Models.Carts;
using Project.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Features.CartItems.Commands.Delete
{
    internal class DeleteCardItemCommandHandler(IMapper mapper, IRepository<Cart> cardItemRepository) : ICommandHandler<DeleteCardItemCommand, Guid>
    {
        public async Task<Response<Guid>> Handle(DeleteCardItemCommand request, CancellationToken cancellationToken)
        {
            var cart = await cardItemRepository.GetByIdAsync(request.id, cancellationToken);
            if (cart is null)
            {
                return Response<Guid>.NotFound("CartItem not found.");
            }

            await cardItemRepository.DeleteAsync(cart, cancellationToken);
            return Response<Guid>.Success(request.id);
        }
    }
}