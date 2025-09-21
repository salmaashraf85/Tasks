using Project.Application.Abstractions.Messaging;
using Project.Application.Abstractions.Repositories;
using Project.Domain.Models.Categories;
using Project.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Features.Categories.Commands.Delete
{
    internal class DeleteCategoryCommandHandler(IRepository<Category> categoryRepository) : ICommandHandler<DeleteCategoryCommand, Guid>
    {
        public async Task<Response<Guid>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await categoryRepository.GetByIdAsync(request.Id, cancellationToken);
            if (category is null)
            {
                return Response<Guid>.NotFound("Category not found.");
            }

            await categoryRepository.DeleteAsync(category, cancellationToken);
            return Response<Guid>.Success(request.Id);
        }
    }
}
