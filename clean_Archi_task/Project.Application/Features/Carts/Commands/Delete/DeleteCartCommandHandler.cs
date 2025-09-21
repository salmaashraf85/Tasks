using AutoMapper;
using Project.Application.Abstractions.Messaging;
using Project.Application.Abstractions.Repositories;
using Project.Application.Features.Carts.Commands.Add;
using Project.Domain.Models.Carts;
using Project.Domain.Models.Categories;
using Project.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Features.Carts.Commands.Delete
{
    public class DeleteCartCommandHandler(IMapper mapper, IRepository<Cart> cardRepository) : ICommandHandler<DeleteCartCommand, Guid>
    {
        public async Task<Response<Guid>> Handle(DeleteCartCommand request, CancellationToken cancellationToken)
        {
            var cart = await cardRepository.GetByIdAsync(request.id, cancellationToken);
            if (cart is null)
            {
                return Response<Guid>.NotFound("Cart not found.");
            }

            await cardRepository.DeleteAsync(cart, cancellationToken);
            return Response<Guid>.Success(request.id);
        }
    }
}