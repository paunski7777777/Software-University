using DungeonsAndCodeWizards.Models.Characters;
using DungeonsAndCodeWizards.Models.Characters.Interfaces;
using DungeonsAndCodeWizards.Models.Factories;
using DungeonsAndCodeWizards.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonsAndCodeWizards.Models.Core
{
    public class DungeonMaster
    {
        private List<Character> characters;
        private Stack<Item> items;
        private CharacterFactory characterFactory;
        private ItemFactory itemFactory;
        private int lastSurvivorRounds;

        public DungeonMaster()
        {
            this.characters = new List<Character>();
            this.items = new Stack<Item>();
            this.characterFactory = new CharacterFactory();
            this.itemFactory = new ItemFactory();
        }

        public string JoinParty(string[] args)
        {
            var result = new StringBuilder();

            string currentFaction = args[0];
            string characterType = args[1];
            string name = args[2];

            Character character = characterFactory.CreateCharacter(currentFaction, characterType, name);
            this.characters.Add(character);

            return $"{character.Name} joined the party!";

        }

        public string AddItemToPool(string[] args)
        {
            string itemName = args[0];
            Item item = itemFactory.CreateItem(itemName);
            this.items.Push(item);

            return $"{itemName} added to pool.";
        }

        public string PickUpItem(string[] args)
        {
            string characterName = args[0];

            Character character = FindCharacter(characterName);

            if (!this.items.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.NoItems);
            }

            var item = this.items.Pop();
            character.ReceiveItem(item);

            return $"{character.Name} picked up {item.GetType().Name}!";
        }

        public string UseItem(string[] args)
        {
            string characterName = args[0];
            string itemName = args[1];

            Character currentCharacter = FindCharacter(characterName);

            var item = currentCharacter.Bag.GetItem(itemName);
            currentCharacter.UseItem(item);

            return $"{currentCharacter.Name} used {itemName}.";
        }

        public string UseItemOn(string[] args)
        {
            string giverName = args[0];
            string receiverName = args[1];
            string itemName = args[2];

            var giver = FindCharacter(giverName);
            var receiver = FindCharacter(receiverName);

            var item = giver.Bag.GetItem(itemName);

            giver.UseItemOn(item, receiver);

            return $"{giver.Name} used {itemName} on {receiver.Name}.";
        }

        public string GiveCharacterItem(string[] args)
        {
            string giverName = args[0];
            string receiverName = args[1];
            string itemName = args[2];

            var giver = FindCharacter(giverName);
            var receiver = FindCharacter(receiverName);

            var item = giver.Bag.GetItem(itemName);

            giver.GiveCharacterItem(item, receiver);

            return $"{giver.Name} gave {receiver.Name} {itemName}.";
        }

        public string GetStats()
        {
            var result = new StringBuilder();

            var sorted = this.characters.OrderByDescending(c => c.IsAlive).ThenByDescending(c => c.Health);

            foreach (var character in sorted)
            {
                result.AppendLine(character.ToString());
            }

            return result.ToString().TrimEnd('\r', '\n');
        }

        public string Attack(string[] args)
        {
            string attackerName = args[0];
            string receiverName = args[1];

            var attacker = FindCharacter(attackerName);
            var target = FindCharacter(receiverName);

            if (!(attacker is IAttackable attackingCharacter))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CannotAttack, attacker.Name));
            }

            attackingCharacter.Attack(target);

            string result =
                $"{attacker.Name} attacks {target.Name} for {attacker.AbilityPoints} hit points! {target.Name} has {target.Health}/{target.BaseHealth} HP and {target.Armor}/{target.BaseArmor} AP left!";

            if (!target.IsAlive)
            {
                result += Environment.NewLine + $"{target.Name} is dead!";
            }

            return result;
        }

        public string Heal(string[] args)
        {
            string healerName = args[0];
            string healingReceiverName = args[1];

            var healer = FindCharacter(healerName);
            var healingReceiver = FindCharacter(healingReceiverName);

            if (!(healer is IHealable healingCharacter))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CannotHeal, healer.Name));
            }

            healingCharacter.Heal(healingReceiver);

            string result =
                $"{healer.Name} heals {healingReceiver.Name} for {healer.AbilityPoints}! {healingReceiver.Name} has {healingReceiver.Health} health now!";

            return result;
        }

        public string EndTurn(string[] args)
        {
            var result = new StringBuilder();

            var aliveCharacters = this.characters.Where(c => c.IsAlive).ToList();

            foreach (var aliveCharacter in aliveCharacters)
            {
                var previousHealth = aliveCharacter.Health;

                aliveCharacter.Rest();

                var currentHealth = aliveCharacter.Health;

                result.AppendLine($"{aliveCharacter.Name} rests ({previousHealth} => {currentHealth})");
            }

            if (aliveCharacters.Count <= 1)
            {
                this.lastSurvivorRounds++;
            }

            return result.ToString().TrimEnd();
        }

        public bool IsGameOver()
        {
            var oneOrZeroSurvivorsLeft = this.characters.Count(c => c.IsAlive) <= 1;
            var lastSurvivor = this.lastSurvivorRounds > 1;

            return oneOrZeroSurvivorsLeft && lastSurvivor;
        }

        private Character FindCharacter(string characterName)
        {
            var currentCharacter = this.characters.First(c => c.Name == characterName);

            if (currentCharacter == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NoCharacter, characterName));
            }

            return currentCharacter;
        }
    }
}
