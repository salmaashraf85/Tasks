using Project.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Features.Categories.Commands.Delete
{
    public record DeleteCategoryCommand(Guid Id) : ICommand<Guid>;
}
