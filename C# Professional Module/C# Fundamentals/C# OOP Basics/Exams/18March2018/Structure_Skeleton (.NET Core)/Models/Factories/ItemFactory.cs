using DungeonsAndCodeWizards.Models.Items;
using System;

namespace DungeonsAndCodeWizards.Models.Factories
{
    public class ItemFactory
    {
        public Item CreateItem(string name)
        {
            switch (name)
            {
                case "HealthPotion":
                    return new HealthPotion();
 
                case "PoisonPotion":
                    return new PoisonPotion();

                case "ArmorRepairKit":
                    return new ArmorRepairKit();
 
                default:
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidItem, name));
            }
        } 
    }
}
