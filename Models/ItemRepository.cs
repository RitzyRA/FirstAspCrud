using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcApp2.Models
{
    public class ItemRepository
    {
        private static List<Item> _items;
        public ItemRepository()
        {
            _items = new List<Item>(){
                new Item() { Id = 1, Name = "Dress", Price = 50.99M, Quantity = 2M},
                new Item() { Id = 2, Name = "Pants", Price = 20.99M, Quantity = 5M},
                new Item() { Id = 3, Name = "Scarf", Price = 5.99M, Quantity = 9M}
            };
        }

        public List<Item> GetAll()
        {
            return _items;
        }

        public bool DeleteById(int id)
        {
            var e = _items.First(e => e.Id == id);
            return _items.Remove(e);
        }
        public void Create(string name, decimal price, decimal quantity)
        {
            var max = int.MinValue;
            foreach (var item in _items)
            {
                if (item.Id > max)
                    max = item.Id;
            }
            _items.Add(new Item() { Id = max + 1, Name = name, Price = price, Quantity = quantity });
        }
        public Item GetById(int id)
        {
            return _items.First(e => e.Id == id);
        }
        public void Update(int updateableId, string updatedName, decimal updatedPrice, decimal updatedQuantity)
        {
            var e = _items.First(e => e.Id == updateableId);
            e.Name = updatedName;
            e.Price = updatedPrice;
            e.Quantity = updatedQuantity;
        }
    }
}
