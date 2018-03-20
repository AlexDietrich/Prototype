using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    class Weapon : Item
    {
        public int damage { get; private set; }
        public float speed { get; private set; }
        public float range { get; private set;  }
        
        public Weapon() { }

        private Weapon(string name, string type) : base(name, type) { }
        
        public override IPrototype Clone(string type, string name, ItemCatagories catagory)
        {
            return new Weapon(name, type);
        }

        public void SetAttribute(int dmg, float spd, float rng, float wgt)
        {
            this.damage = dmg;
            this.range = rng;
            this.speed = spd;
            this.weight = wgt;
        }
    }
}
