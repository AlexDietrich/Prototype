using System.Collections.Generic;
using Prototype.Prototype;

namespace Prototype.ItemLoader
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
                IDictionary<string, string> items = new Dictionary<string, string>();
                //split the line of the config file to get each attribute of the weapon
                var seperatedLine = line.Split(';');
                //Go through each attribute from the collectibles config file and save it as a key-value pair in the dictionary
                foreach (var item in seperatedLine)
                {
                    var singleItem = item.Split('=');
                    items.Add(singleItem[0], singleItem[1]);
                }
                //add the collectible to the referenced list. 
                collectibles.Add(items["name"],
                    new Collectible(items["name"], items["type"], float.Parse(items["speed"]), float.Parse(items["time"])));
            }
        }
    }
}