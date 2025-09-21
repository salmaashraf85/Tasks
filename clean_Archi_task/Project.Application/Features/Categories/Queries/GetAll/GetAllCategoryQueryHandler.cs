using AutoMapper;
using Project.Application.Abstractions.Messaging;
using Project.Application.Abstractions.Repositories;
using Project.Application.Features.Categories.Dtos;
using Project.Application.Features.Products.Dtos;
using Project.Application.Features.Products.Queries.GetAll;
using Project.Application.Features.Categories.Specifications;
using Project.Domain.Models.Categories;
using Project.Domain.Models.Products;
using Project.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Features.Categories.Queries.GetAll
{
    internal class GetAllCategoryQueryHandler(IMapper mapper, IReadRepository<Category> CategoryRepository) : IQueryHandler<GetAllCategoryQuery, PaginatedResult<CategoryDto>>
    {
        public async Task<Response<PaginatedResult<CategoryDto>>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            var products = await CategoryRepository
                .ListAsync(new CategorySpec(request.Name,
                    request.PageSize,
                    request.PageNumber), cancellationToken);
            var productsCount = await CategoryRepository
                .CountAsync(new CategorySpec(request.Name,
                    request.PageSize,
                    request.PageNumber), cancellationToken);

            var mappedProducts = mapper.Map<IEnumerable<CategoryDto>>(products);

            return Response<CategoryDto>.GetData(mappedProducts, request.PageNumber, request.PageSize, productsCount);
        }
    }
}
