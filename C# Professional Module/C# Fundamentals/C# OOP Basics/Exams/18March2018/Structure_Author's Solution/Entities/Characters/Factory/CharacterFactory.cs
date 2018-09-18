using System;
using DungeonsAndCodeWizards.Entities.Characters.Enums;

namespace DungeonsAndCodeWizards.Entities.Characters.Factory
{
	public class CharacterFactory
	{
		public Character CreateCharacter(string faction, string type, string name)
		{
			if (!Enum.TryParse<Faction>(faction, out var parsedFaction))
			{
				throw new ArgumentException($"Invalid faction \"{faction}\"!");
			}

			Character character;
			switch (type)
			{
				case "Warrior":
					character = new Warrior(name, parsedFaction);
					break;
				case "Cleric":
					character = new Cleric(name, parsedFaction);
					break;
				default:
					throw new ArgumentException($"Invalid character type \"{type}\"!");
			}

			return character;
		}
	}

	// no reflection allowed ;(
	//public Character CreateCharacter(string faction, string type, string name)
	//{
	//	if (!Enum.TryParse<Faction>(faction, out var parsedFaction))
	//	{
	//		throw new ArgumentException($"Invalid faction \"{faction}\"!");
	//	}
	
	//	var characterType = Assembly.GetExecutingAssembly()
	//		.GetTypes()
	//		.FirstOrDefault(t => t.Name == type);

	//	if (characterType == null)
	//	{
	//		throw new ArgumentException($"Invalid character type \"{type}\"!");
	//	}

	//	var character = (Character)Activator.CreateInstance(characterType, name, parsedFaction);
	//	return character;
	//}
}
