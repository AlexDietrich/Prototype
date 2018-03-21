using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    internal abstract class Item : IPrototype
    {
        public string name { get; private set; }
        public string type { get; private set; }
        public float weight { get; protected set; } = 0;

        protected Item() { }
        protected Item(string name, string type, float weight)
        {
            this.name = name;
            this.type = type;
            this.weight = weight;
        }

        public abstract IPrototype Clone();
    }
}
