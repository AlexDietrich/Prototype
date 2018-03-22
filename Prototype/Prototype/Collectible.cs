using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype.Prototype
{
    internal class Collectible : Item
    {
        public float speedUp { get; private set; } = 0f;
        public float timeUp { get; private set; } = 0f;

        public Collectible(string name, string type, float speed, float time) : base(name, type, 0f)
        {
            this.speedUp = speed;
            this.timeUp = time;
        }

        public override IPrototype Clone()
        {
            return (IPrototype)this.MemberwiseClone();
        }
    }
}