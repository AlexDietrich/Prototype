using System;
using System.Collections.Generic;
using Prototype.Prototype;

namespace Prototype.ItemLoader
{
    internal class WeaponLoader : ItemLoader
    {
        public override void LoadItems(ref IDictionary<string, Item> weapons)
        {
            //get all the lines of the config into the string array line by line
            var lines = System.IO.File.ReadAllLines(@"config_weapon");
            foreach (var line in lines)
            {
                //dictionary which saves each attribute of the weapon in the config file  as a key-value pair
                IDictionary<string, string> _items = new Dictionary<string, string>();
                //split the line of the config file to get each attribute of the weapon
                var seperatedLine = line.Split(';');
                //Go through each attribute from the weapons config file and save it as a key-value pair in the dictionary
                foreach (var item in seperatedLine)
                {
                    var singleItem = item.Split('=');
                    _items.Add(singleItem[0], singleItem[1]);
                }

                //add the weapon to the referenced item-list.
                weapons.Add(_items["name"],
                    new Weapon(_items["name"], _items["type"], Int32.Parse(_items["damage"]),
                        float.Parse(_items["speed"]), float.Parse(_items["range"]), float.Parse(_items["weight"])));
            }
        }
    }
}
