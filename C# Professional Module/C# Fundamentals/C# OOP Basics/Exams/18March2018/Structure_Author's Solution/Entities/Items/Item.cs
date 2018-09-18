using System;
using DungeonsAndCodeWizards.Entities.Characters;

namespace DungeonsAndCodeWizards.Entities.Items
{
    public abstract class Item
    {
	    protected Item(int weight)
	    {
		    this.Weight = weight;
	    }

	    public int Weight { get; }

		public virtual void AffectCharacter(Character character)
		{
			if (!character.IsAlive)
			{
				throw new InvalidOperationException("Must be alive to perform this action!");
			}
		}
	}
}
