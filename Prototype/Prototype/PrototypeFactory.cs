using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prototype.Prototype;

namespace Prototype
{
    internal class PrototypeFactory
    {
        private readonly IDictionary<string, Item> _items = new Dictionary<string, Item>();

        private PrototypeFactory()
        {
            var collectibles = new CollectibleLoader();
            var weapons = new WeaponLoader();

            weapons.LoadItems(ref _items);
            collectibles.LoadItems(ref _items);
        }

        public static PrototypeFactory Instance { get; } = new PrototypeFactory();

        public IPrototype Clone(string name)
        {
            IPrototype p = null;
            if (_items.ContainsKey(name))
            {
                p = _items[name].Clone();
            }
            else
            {
                throw new ArgumentException("Kein Item mit Namen: " + name + " gefunden!");
            }
            return p;
        }
    }
}
