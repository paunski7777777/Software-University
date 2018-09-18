using System;

namespace DungeonsAndCodeWizards.Entities.Items.Factory
{
	public class ItemFactory
	{
		public Item CreateItem(string name)
		{
			Item item;
			switch (name)
			{
				case "HealthPotion":
					item = new HealthPotion();
					break;
				case "PoisonPotion":
					item = new PoisonPotion();
					break;
				case "ArmorRepairKit":
					item = new ArmorRepairKit();
					break;
				default:
					throw new ArgumentException($"Invalid item \"{name}\"!");
			}

			return item;
		}

		//no reflection allowed ;(
		//public Item CreateItem(string name)
		//{
		//	var type = Assembly.GetExecutingAssembly()
		//	  .GetTypes()
		//	  .FirstOrDefault(t => t.Name == name);

		//	if (type == null)
		//	{
		//		throw new ArgumentException($"Invalid item \"{name}\"!");
		//	}

		//	var item = (Item)Activator.CreateInstance(type);
		//	return item;
		//}
	}
}
