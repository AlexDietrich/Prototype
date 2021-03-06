﻿using System;
using System.Collections.Generic;
using Prototype.ItemLoader;

namespace Prototype.Prototype
{
    internal class PrototypeFactory
    {
        private readonly IDictionary<string, Item> _items = new Dictionary<string, Item>();

        private PrototypeFactory()
        {
            var collectibles = new CollectibleLoader();
            var weapons = new WeaponLoader();

            weapons.LoadItems(ref _items);
            collectibles.LoadItems(ref _items);
        }

        public static PrototypeFactory Instance { get; } = new PrototypeFactory();

        public IPrototype Clone(string name)
        {
            if (!_items.ContainsKey(name)) throw new ArgumentException("Kein Item mit Namen: " + name + " gefunden!");
            var p = _items[name].Clone();
            return p;
        }
    }
}
