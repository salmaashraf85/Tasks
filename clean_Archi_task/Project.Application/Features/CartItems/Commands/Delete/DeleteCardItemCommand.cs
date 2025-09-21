using Project.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Features.CartItems.Commands.Delete
{
    public record DeleteCardItemCommand(Guid id) : ICommand<Guid>;
}
