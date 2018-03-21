using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    internal class Weapon : Item
    {
        public int damage { get; private set; }
        public float speed { get; private set; }
        public float range { get; private set;  }
        
        public Weapon() { }

        public Weapon(string name, string type, int dmg, float spd, float rng, float wgt) : base(name, type, wgt)
        {
            this.damage = dmg;
            this.speed = spd;
            this.range = rng;
        }
        
        public override IPrototype Clone()
        {
            return (IPrototype)this.MemberwiseClone();
        }
    }
}
