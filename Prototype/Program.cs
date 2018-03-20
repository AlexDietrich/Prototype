using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prototype.Prototype;

namespace Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Item> items = new List<Item>();
            List<Collectibles> collectibleItems = new List<Collectibles>();
            List<Weapon> weaponItems = new List<Weapon>();
            PrototypeFactory itemFactory = PrototypeFactory.Instance;

            Weapon longSword = (Weapon)itemFactory.Clone("Breitschwert", "Longsword", ItemCatagories.Weapon);
            longSword.SetAttribute(100, 1.2f, 20f, 5.5f);
            items.Add(longSword);
            weaponItems.Add(longSword);

            Weapon knife = (Weapon)itemFactory.Clone("Schlachtmesser", "Knife", ItemCatagories.Weapon);
            knife.SetAttribute(10, 2f, 10f, 2.2f);
            items.Add(knife);
            weaponItems.Add(knife);

            Weapon shortSword = (Weapon)itemFactory.Clone("Schweinetöter", "Shortsword", ItemCatagories.Weapon);
            shortSword.SetAttribute(55, 1.6f, 15f, 3.8f);
            items.Add(shortSword);
            weaponItems.Add(shortSword);

            Collectibles speedUp = (Collectibles)itemFactory.Clone("HuiHuiRun", "Speed-Up-Item", ItemCatagories.Collectible);
            speedUp.SetSpeedUp(2.0f);
            items.Add(speedUp);
            collectibleItems.Add(speedUp);

            Collectibles timeUp = (Collectibles)itemFactory.Clone("Slow down Bro!", "Time-Up-Item", ItemCatagories.Collectible);
            timeUp.SetTimeUp(3.2f);
            items.Add(timeUp);
            collectibleItems.Add(timeUp);

            ReadConfigWeapon(ref items, ref weaponItems);

            //Print all the lists to show that each element is a clone from the same class but with different types saved in it.
            Console.WriteLine("The list of all items:");
            foreach (var item in items)
            {
                Console.WriteLine("Name = " + item.name + " ... Type = " + item.type);
            }

            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("The list of Weapons:");

            foreach (var weapon in weaponItems)
            {
                Console.WriteLine("Name = " + weapon.name + " ... Type = " + weapon.type + " ... Damage = " + weapon.damage + " ... Range = " + weapon.range + " ... weight = " + weapon.weight);
            }

            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("The list of Collectibles:");

            foreach (var collectible in collectibleItems)
            {
                Console.WriteLine("Name = " + collectible.name + " ... Type = " + collectible.type + " ... Speed = " + collectible.speedUp + " ... Time = " + collectible.timeUp);
            }

            //Finding the correct Item in the Itemslist and print the correct stats into the console.
            foreach (var item in items)
            {
                if (item.GetType() == typeof(Collectibles) && item.name == "HuiHuiRun")
                {
                    Collectibles collectible = (Collectibles)item;
                    Console.WriteLine("------------------------------------------------------");
                    Console.WriteLine("Found the correct collectible out of the Items-List:");
                    Console.WriteLine("Name = " + collectible.name + " ... Speed-Up = " + collectible.speedUp);
                }
            }
        }

        /// <summary>
        /// Read the weapon config-file and add it to the given list of items and / or weapons. 
        /// </summary>
        /// <param name="items">list of items</param>
        /// <param name="weaponItems">list of weapons</param>
        private static void ReadConfigWeapon(ref List<Item> items, ref List<Weapon> weaponItems)
        {
            //get instance of the PrototypeFactory which you need to clone the prototype classes
            PrototypeFactory itemFactory = PrototypeFactory.Instance;
            //get all the lines of the config into the string array line by line
            string[] lines = System.IO.File.ReadAllLines(@"config");
            foreach (var line in lines)
            {
                //dictionary which saves each attribute of the weapon in the config file  as a key-value pair
                IDictionary<string, string> _items = new Dictionary<string, string>();
                //split the line of the config file to get each attribute of the weapon
                string[] seperatedLine = line.Split(';');
                //Go through each attribute from the weapons config file and save it as a key-value pair in the dictionary
                foreach (var item in seperatedLine)
                {
                    string[] singleItem = item.Split('=');
                    _items.Add(singleItem[0], singleItem[1]);
                }
                //give the seperated values to the itemfactory to get the weapon clone, set the attributes of the weapon before adding to given lists.
                Weapon weapon = (Weapon)itemFactory.Clone(_items["name"], _items["type"], ItemCatagories.Weapon);
                weapon.SetAttribute(Int32.Parse(_items["damage"]), float.Parse(_items["speed"]), float.Parse(_items["range"]), float.Parse(_items["weight"]));
                items.Add(weapon);
                weaponItems.Add(weapon);
            }

        }

    }
}
