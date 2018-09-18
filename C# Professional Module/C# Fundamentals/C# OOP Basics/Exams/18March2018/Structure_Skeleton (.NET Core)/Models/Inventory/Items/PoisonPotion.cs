using DungeonsAndCodeWizards.Models.Characters;
using System;

namespace DungeonsAndCodeWizards.Models.Items
{
    public class PoisonPotion : Item
    {
        public PoisonPotion() 
            : base(5)
        {
        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);

            character.Health = Math.Max(0, character.Health - 20);

            if (character.Health < 1)
            {
                character.IsAlive = false;
            }
        }
    }
}
