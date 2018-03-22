using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prototype.Prototype;

namespace Prototype
{
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    [SuppressMessage("ReSharper", "ArrangeTypeModifiers")]
    class Program
    {
        [SuppressMessage("ReSharper", "ArrangeTypeMemberModifiers")]
        static void Main(string[] args)
        {
            var itemFactory = PrototypeFactory.Instance;
            var items = new List<Item>();
            var collectibleItems = new List<Collectible>();
            var weaponItems = new List<Weapon>();

            try
            {
                var longSword = (Weapon) itemFactory.Clone("Aschenbringer");
                items.Add(longSword);
                weaponItems.Add(longSword);

                var knife = (Weapon)itemFactory.Clone("Schlachtmesser");
                items.Add(knife);
                weaponItems.Add(knife);

                var shortSword = (Weapon)itemFactory.Clone("Höllentor");
                items.Add(shortSword);
                weaponItems.Add(shortSword);
                
                var healPotion = (Collectible)itemFactory.Clone("Heiltrank");
                items.Add(healPotion);
                collectibleItems.Add(healPotion);

                var manaPotion = (Collectible)itemFactory.Clone("Manatrank");
                items.Add(manaPotion);
                collectibleItems.Add(manaPotion);

                var speedUp = (Collectible)itemFactory.Clone("Geschwindigkeitstrank");
                items.Add(speedUp);
                collectibleItems.Add(speedUp);

                //Try to clone an item which doesn't exist in the config file. Program should write an Error into the console but don't break.
                var chuckNorrisBooster = (Collectible) itemFactory.Clone("ChuckNorris");
                items.Add(chuckNorrisBooster);
                collectibleItems.Add(chuckNorrisBooster);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("RuntimeException beim Erstellen der Arbeitsobjekte: " + e.Message);
            }

            #region Konsolenausgabe der Listen
            //Print all the lists to show that each element is a clone from the same class but with different types saved in it.
            Console.WriteLine("The list of all items:");
            foreach (var item in items)
            {
                Console.WriteLine("Name = " + item?.name + " ... Type = " + item?.type);
            }

            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("The list of weapons:");

            foreach (var weapon in weaponItems)
            {
                Console.WriteLine("Name = " + weapon?.name + " ... Type = " + weapon?.type + " ... Damage = " + weapon?.damage + " ... Range = " + weapon?.range + " ... weight = " + weapon?.weight);
            }

            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("The list of collectibles:");

            foreach (var collectible in collectibleItems)
            {
                Console.WriteLine("Name = " + collectible?.name + " ... Type = " + collectible?.type + " ... Speed = " + collectible?.speedUp + " ... Time = " + collectible?.timeUp);
            }

            //Finding the correct Item in the Itemslist and print the correct stats into the console.
            foreach (var item in items)
            {
                if (item?.GetType() != typeof(Collectible) || item?.name != "Geschwindigkeitstrank") continue;
                var collectible = (Collectible)item;
                Console.WriteLine("------------------------------------------------------");
                Console.WriteLine("Found the \"Geschwindigkeitstrank\" from the item-list:");
                Console.WriteLine("Name = " + collectible.name + " ... Speed-Up = " + collectible.speedUp);
            }

            Console.WriteLine("------------------------------------------------------");

            foreach (var item in items)
            {
                if (item?.GetType() != typeof(Weapon) || item?.name != "Schlachtmesser") continue;
                var weapon = (Weapon)item;
                Console.WriteLine("Found the \"Schlachtmesser\" from the item-list:");
                Console.WriteLine("Name = " + weapon.name + " ... Type = " + weapon.type + " ... Damage = " + weapon.damage);
                //If i found one weapon with the given name, stop to iterate through all elements.
                break;
            }
            #endregion

        }
    }
}
