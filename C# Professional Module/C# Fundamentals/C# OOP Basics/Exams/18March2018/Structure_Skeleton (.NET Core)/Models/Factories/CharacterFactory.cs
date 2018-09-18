using DungeonsAndCodeWizards.Models.Characters;
using DungeonsAndCodeWizards.Models.Items;
using System;

namespace DungeonsAndCodeWizards.Models.Factories
{
    public class CharacterFactory
    {
        public Character CreateCharacter(string faction, string characterType, string name)
        {
            bool validFaction = Enum.TryParse<Faction>(faction, out var parsedFaction);

            if (!validFaction)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidFaction, faction));
            }

            switch (characterType)
            {
                case "Warrior":
                    return new Warrior(name, parsedFaction);

                case "Cleric":
                    return new Cleric(name, parsedFaction);

                default:
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidCharacterType, characterType));
            }
        }
    }
}
