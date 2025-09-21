using AutoMapper;
using Project.Application.Abstractions.Messaging;
using Project.Application.Abstractions.Repositories;
using Project.Application.Features.Categories.Commands.Add;
using Project.Domain.Models.Categories;
using Project.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Features.Categories.Commands.Update
{
    internal class UpdateCategoryCommandHandler(IMapper mapper, IRepository<Category> categoryRepository) : ICommandHandler<UpdateCategoryCommand, Guid>
    {
        public async Task<Response<Guid>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await categoryRepository.GetByIdAsync(request.Id, cancellationToken);
            if (category == null)
            {
                return Response<Guid>.Failure("Category not found");
            }

            mapper.Map(request, category); 
            await categoryRepository.UpdateAsync(category, cancellationToken);

            return Response<Guid>.Success(category.Id);
        }
    }
}