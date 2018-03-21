using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prototype.Prototype;

namespace Prototype
{
    internal class CollectibleLoader : ItemLoader
    {
        public override void LoadItems(ref IDictionary<string, Item> collectibles)
        {
            //get all the lines of the config into the string array line by line
            var lines = System.IO.File.ReadAllLines(@"config_collectibles");
            foreach (var line in lines)
            {
                //dictionary which saves each attribute of the collectible in the config file  as a key-value pair
                IDictionary<string, string> _items = new Dictionary<string, string>();
                //split the line of the config file to get each attribute of the weapon
                var seperatedLine = line.Split(';');
                //Go through each attribute from the collectibles config file and save it as a key-value pair in the dictionary
                foreach (var item in seperatedLine)
                {
                    var singleItem = item.Split('=');
                    _items.Add(singleItem[0], singleItem[1]);
                }

                //add the collectible to the referenced list. 
                collectibles.Add(_items["name"],
                    new Collectible(_items["name"], _items["type"], float.Parse(_items["speed"]), float.Parse(_items["time"])));
            }
        }
    }
}
