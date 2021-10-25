using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcApp2.Models
{
    public interface IItemRepository
    {
        IEnumerable<Item> GetAll();
        bool DeleteById(int? id);
        void Create(string name, decimal price, decimal quantity);
        Item GetById(int id);
        void Update(int updateableId, string updatedName, decimal updatedPrice, decimal updatedQuantity);
    }
}
