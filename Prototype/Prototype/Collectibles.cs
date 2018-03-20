using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype.Prototype
{
    class Collectibles : Item
    {
        public float speedUp { get; private set; } = 0f;
        public float timeUp { get; private set; } = 0f;

        public Collectibles() { }

        private Collectibles(string name, string type) : base(name, type) { }

        public override IPrototype Clone(string type, string name, ItemCatagories catagory)
        {
            return new Collectibles(name, type);
        }

        public void SetSpeedUp(float spd)
        {
            this.speedUp = spd;
        }

        public void SetTimeUp(float tm)
        {
            this.timeUp = tm;
        }
    }
}
