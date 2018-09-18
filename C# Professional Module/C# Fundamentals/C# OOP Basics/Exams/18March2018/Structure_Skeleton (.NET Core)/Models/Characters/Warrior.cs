using DungeonsAndCodeWizards.Models.Characters.Interfaces;
using System;
using DungeonsAndCodeWizards.Models.Items;

namespace DungeonsAndCodeWizards.Models.Characters
{
    public class Warrior : Character, IAttackable
    {
        public Warrior(string name, Faction faction)
            : base(name, 100, 50, 40, new Satchel(), faction)
        {

        }

        public void Attack(Character character)
        {
            IsCharacterAlive();

            if (character == this)
            {
                throw new InvalidOperationException(ExceptionMessages.CannotAttackSelf);
            }
            if (this.Faction == character.Faction)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.FriendlyFire, character.Faction));
            }

            character.TakeDamage(this.AbilityPoints);
        }
    }
}
