using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeWork7
{
    internal class Rack<T>(string name) : IReadOnlyRack<T> where T : Instrument
    {
        private readonly List<T> items = [];

        public string Name => name;
        public int Count => items.Count;
        public decimal TotalPrice => items.Sum(x => x.Price);

        public T this[int index] => items[index];

        public void Add(T item) => items.Add(item);
        public void RemoveAt(int index) => items.RemoveAt(index);

        public T? Cheapest()
        {
            if (items.Count == 0)
                return null;

            T cheapest = items[0];

            foreach (T item in items)
            {
                if (item.Price < cheapest.Price)
                    cheapest = item;
            }

            return cheapest;
        }

        public List<T> ByBrand(string brand)
        {
            return items.FindAll(x =>
                x.Manufacturer.Equals(
                    brand, StringComparison.OrdinalIgnoreCase));
        }
        public override string ToString()
        {
            return $"{Name} ({Count}): {string.Join(", ", items)}";
        }
    }    
}
