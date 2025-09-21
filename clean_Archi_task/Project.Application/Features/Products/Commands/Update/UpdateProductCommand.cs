using Project.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Features.Products.Commands.Update
{
    public record UpdateProductCommand(Guid Id, string Name) : ICommand<Guid>;
}
