using AutoMapper;
using Project.Application.Abstractions.Messaging;
using Project.Application.Abstractions.Repositories;
using Project.Application.Features.CartItems.Commands.Add;
using Project.Domain.Models.Carts;
using Project.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Features.Carts.Commands.Add
{
    public class AddCartCommandHandler(IMapper mapper, IRepository<Cart> cardRepository) : ICommandHandler<AddCartCommand, Guid>
    {
        public async Task<Response<Guid>> Handle(AddCartCommand request, CancellationToken cancellationToken)
        {
            var cart = mapper.Map<Cart>(request);
            await cardRepository.AddAsync(cart, cancellationToken);
            return Response<Guid>.Created(cart.Id);
        }
    }
}