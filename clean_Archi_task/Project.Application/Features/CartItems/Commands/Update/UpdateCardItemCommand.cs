using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Project.Application.Abstractions.Messaging;

namespace Project.Application.Features.CartItems.Commands.Update
{
    public record UpdateCardItemCommand (Guid id, int Quantity) :ICommand<Guid>;
}
