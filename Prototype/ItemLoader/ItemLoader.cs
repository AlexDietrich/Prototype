using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    internal abstract class ItemLoader
    {
        public abstract void LoadItems(ref IDictionary<string, Item> items);
    }
}
