using DungeonsAndCodeWizards.Models.Characters.Interfaces;
using System;
using DungeonsAndCodeWizards.Models.Items;

namespace DungeonsAndCodeWizards.Models.Characters
{
    public class Cleric : Character, IHealable
    {
        public Cleric(string name, Faction faction)
            : base(name, 50, 25, 40, new Backpack(), faction)
        {

        }

        public override double RestHealMultiplier => 0.5;

        public void Heal(Character character)
        {
            IsCharacterAlive();

            if (!character.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.MustBeAlive);
            }
            if (this.Faction != character.Faction)
            {
                throw new InvalidOperationException(ExceptionMessages.CannotHealEnemy);
            }

            character.Health = Math.Min(character.BaseHealth, character.Health + this.AbilityPoints);
        }
    }
}
