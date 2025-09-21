using AutoMapper;
using Project.Application.Abstractions.Messaging;
using Project.Application.Abstractions.Repositories;
using Project.Application.Features.Categories.Dtos;
using Project.Application.Features.Products.Dtos;
using Project.Application.Features.Products.Queries.GetById;
using Project.Domain.Models.Categories;
using Project.Domain.Models.Products;
using Project.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Features.Categories.Queries.GetById
{
    internal class GetCategoryByIdQueryHandler(IMapper mapper, IReadRepository<Category> CategoryRepository) : IQueryHandler<GetCategoryByIdQuery, CategoryDto>
    {
        public async Task<Response<CategoryDto>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await CategoryRepository.GetByIdAsync(request.Id, cancellationToken);
            if (product == null)
            {
                return Response<CategoryDto>.NotFound("Category not found");
            }

            var productDto = mapper.Map<CategoryDto>(product);
            return Response<CategoryDto>.Success(productDto);
        }
    }
    
}
