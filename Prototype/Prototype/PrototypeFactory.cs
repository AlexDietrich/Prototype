using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prototype.Prototype;

namespace Prototype
{
    class PrototypeFactory : IPrototype
    {
        private readonly Weapon _weapon = new Weapon();
        private readonly Collectibles _collectible = new Collectibles();

        private PrototypeFactory() { }

        public static PrototypeFactory Instance { get; } = new PrototypeFactory();

        public IPrototype Clone(string type, string name, ItemCatagories category)
        {
            IPrototype p = null;
            switch (category)
            {
                case ItemCatagories.Weapon:
                    p = _weapon.Clone(name, type, category);
                    break;
                case ItemCatagories.Collectible:
                    p = _collectible.Clone(name, type, category);
                    break;
                default:
                    throw new NullReferenceException();
            }
            return p;
        }
    }
}
