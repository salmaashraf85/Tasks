using AutoMapper;
using Project.Application.Abstractions.Messaging;
using Project.Application.Abstractions.Repositories;
using Project.Application.Features.Categories.Commands.Update;
using Project.Domain.Models.Categories;
using Project.Domain.Models.Products;
using Project.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Features.Products.Commands.Update
{
    internal class UpdateProductCommandHandler(IMapper mapper, IRepository<Product> productRepository) : ICommandHandler<UpdateProductCommand, Guid>
    {
        public async Task<Response<Guid>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await productRepository.GetByIdAsync(request.Id, cancellationToken);
            if (product == null)
            {
                return Response<Guid>.Failure("product not found");
            }

            mapper.Map(request, product);
            await productRepository.UpdateAsync(product, cancellationToken);

            return Response<Guid>.Success(product.Id);
        }
    }
}