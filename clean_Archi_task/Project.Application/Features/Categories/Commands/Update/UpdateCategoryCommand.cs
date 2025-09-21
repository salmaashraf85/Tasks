using Project.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Features.Categories.Commands.Update
{
    public record UpdateCategoryCommand(Guid Id,string Name) : ICommand<Guid>;
}
