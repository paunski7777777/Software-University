using System;
using System.Collections.Generic;
using System.Linq;

namespace DungeonsAndCodeWizards.Models.Items
{
    public abstract class Bag
    {
        private const int DefaultBagCapacity = 100;

        public int Capacity { get; set; }

        private readonly List<Item> items;

        public IReadOnlyCollection<Item> Items { get { return this.items.AsReadOnly(); } }

        public int Load => Items.Sum(i => i.Weight);

        public void AddItem(Item item)
        {
            if (this.Load + item.Weight > this.Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.BagIsFull);
            }

            this.items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (!this.Items.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.BagIsEmpty);
            }
            if (this.Items.Any(i => i.GetType().Name != name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ItemDoesNotExist, name));
            }

            var item = this.Items.First(i => i.GetType().Name == name);
            this.items.Remove(item);

            return item;
        }

        protected Bag(int capacity = DefaultBagCapacity)
        {
            this.Capacity = capacity;
            this.items = new List<Item>();
        }
    }
}
