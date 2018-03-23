using System.Collections.Generic;
using Prototype.Prototype;

namespace Prototype.ItemLoader
{
    internal abstract class ItemLoader
    {
        public abstract void LoadItems(ref IDictionary<string, Item> items);
    }
}
