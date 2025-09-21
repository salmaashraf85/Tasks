using AutoMapper;
using Project.Application.Abstractions.Messaging;
using Project.Application.Abstractions.Repositories;
using Project.Domain.Models.CartItems;
using Project.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Features.CartItems.Commands.Update
{
    public class UpdateCardItemCommandHandler(IMapper mapper, IRepository<CartItem> cartItemRepository) : ICommandHandler<UpdateCardItemCommand, Guid>
    {
        public async Task<Response<Guid>> Handle(UpdateCardItemCommand request, CancellationToken cancellationToken)
        {
            var category = await cartItemRepository.GetByIdAsync(request.id, cancellationToken);
            if (category == null)
            {
                return Response<Guid>.Failure("Cart item not found");
            }

            mapper.Map(request, category);
            await cartItemRepository.UpdateAsync(category, cancellationToken);

            return Response<Guid>.Success(category.Id);
        }
    }
}