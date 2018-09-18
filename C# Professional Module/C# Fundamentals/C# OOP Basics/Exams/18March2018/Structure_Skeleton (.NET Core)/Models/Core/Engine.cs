

using DungeonsAndCodeWizards.Models.Core;
using System;
using System.Linq;

namespace DungeonsAndCodeWizards.Core
{
    public class Engine
    {
        private bool isRunning;
        private readonly DungeonMaster dungeonMaster;

        public Engine()
        {
            this.dungeonMaster = new DungeonMaster();
            this.isRunning = true;
        }

        public void Run()
        {
            while (this.isRunning)
            {
                string command = Console.ReadLine();

                try
                {
                    this.ReadCommand(command);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine("Parameter Error: " + e.Message);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine("Invalid Operation: " + e.Message);
                }

                if (this.dungeonMaster.IsGameOver() || this.isRunning == false)
                {
                    Console.WriteLine("Final stats:");
                    Console.WriteLine(this.dungeonMaster.GetStats());
                    this.isRunning = false;
                }
            }
        }

        private void ReadCommand(string command)
        {
            if (string.IsNullOrEmpty(command))
            {
                this.isRunning = false;
                return;
            }

            var commandArgs = command.Split();
            var commandName = commandArgs[0];
            var args = commandArgs.Skip(1).ToArray();

            var output = string.Empty;
            switch (commandName)
            {
                case "JoinParty":
                    output = this.dungeonMaster.JoinParty(args);
                    break;
                case "AddItemToPool":
                    output = this.dungeonMaster.AddItemToPool(args);
                    break;
                case "PickUpItem":
                    output = this.dungeonMaster.PickUpItem(args);
                    break;
                case "UseItem":
                    output = this.dungeonMaster.UseItem(args);
                    break;
                case "GiveCharacterItem":
                    output = this.dungeonMaster.GiveCharacterItem(args);
                    break;
                case "UseItemOn":
                    output = this.dungeonMaster.UseItemOn(args);
                    break;
                case "GetStats":
                    output = this.dungeonMaster.GetStats();
                    break;
                case "Attack":
                    output = this.dungeonMaster.Attack(args);
                    break;
                case "Heal":
                    output = this.dungeonMaster.Heal(args);
                    break;
                case "EndTurn":
                    output = this.dungeonMaster.EndTurn(args);
                    break;
            }

            if (output != string.Empty)
            {
                Console.WriteLine(output);
            }
        }
    }
}
