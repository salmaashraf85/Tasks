using Project.Domain.Models.Base;
using Project.Domain.Models.CartItems;
using Project.Domain.Models.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain.Models.Carts
{
    public class Cart : Entity, IAuditableEntity, ISoftDeletableEntity
    {
       // public Guid UserId { get; set; }
        public ICollection<CartItem> Items { get; set; } = new List<CartItem>();
    }
}