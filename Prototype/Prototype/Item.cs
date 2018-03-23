namespace Prototype.Prototype
{
    internal abstract class Item : IPrototype
    {
        public string name { get; private set; }
        public string type { get; private set; }
        public float weight { get; private set; } = 0;

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
