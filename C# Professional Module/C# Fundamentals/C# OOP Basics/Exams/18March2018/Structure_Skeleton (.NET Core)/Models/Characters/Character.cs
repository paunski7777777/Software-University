using DungeonsAndCodeWizards.Models.Items;
using System;

namespace DungeonsAndCodeWizards.Models.Characters
{
    public abstract class Character
    {
        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.ItemNotNull);
                }
                name = value;
            }
        }

        public double BaseHealth { get; set; }
        private double health;

        public double Health
        {
            get { return health; }
            set
            {
                health = Math.Min(value, this.BaseHealth);
            }
        }



        public double BaseArmor { get; set; }
        private double armor;

        public double Armor
        {
            get { return armor; }
            set
            {
                armor = Math.Min(value, this.BaseArmor);
            }
        }


        public double AbilityPoints { get; set; }

        public virtual Bag Bag { get; set; }

        public Faction Faction { get; set; }

        public bool IsAlive { get; set; }

        public virtual double RestHealMultiplier { get; set; }

        public void TakeDamage(double hitPoints)
        {
            IsCharacterAlive();

            var hitpointsLeftAfterArmorDamage = Math.Max(0, hitPoints - this.Armor);

            this.Armor = Math.Max(0, this.Armor - hitPoints);
            this.Health = Math.Max(0, this.Health - hitpointsLeftAfterArmorDamage);

            if (this.Health == 0)
            {
                this.IsAlive = false;
            }

        }

        public void Rest()
        {
            IsCharacterAlive();

            this.Health = Math.Min(this.Health + this.BaseHealth * RestHealMultiplier, this.BaseHealth);
        }

        public void UseItem(Item item)
        {
            item.AffectCharacter(this);
        }

        public void UseItemOn(Item item, Character character)
        {
            item.AffectCharacter(character);
        }

        public void GiveCharacterItem(Item item, Character character)
        {
            character.ReceiveItem(item);
        }

        public void ReceiveItem(Item item)
        {
            this.Bag.AddItem(item);
        }

        public void IsCharacterAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.MustBeAlive);
            }
        }
        protected Character(string name, double health, double armor, double abilityPoints, Bag bag, Faction faction)
        {
            this.Name = name;

            this.BaseHealth = health;
            this.Health = health;

            this.BaseArmor = armor;
            this.Armor = armor;

            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
            this.Faction = faction;

            this.IsAlive = true;
            this.RestHealMultiplier = 0.2;
        }

        public override string ToString()
        {
            var alive = this.IsAlive ? "Alive" : "Dead";

            return $"{this.Name} - HP: {this.Health}/{this.BaseHealth}, AP: {this.Armor}/{this.BaseArmor}, Status: {alive}";
        }
    }
}
