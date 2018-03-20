using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    class Item : IPrototype
    {
        public string name { get; private set; }
        public string type { get; private set; }
        public float weight { get; protected set; } = 0;

        protected Item() { }
        protected Item(string name, string type)
        {
            this.name = name;
            this.type = type; 
        }

        public virtual IPrototype Clone(string type, string name, ItemCatagories catagory)
        {
            throw new ConfigurationErrorsException();
        }
    }
}
