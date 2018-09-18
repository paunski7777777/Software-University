using System;
using System.Collections.Generic;
using System.Linq;

public class MilitaryElite
{
    public static void Main()
    {
        var soldiers = new List<ISoldier>();

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] tokens = input.Split();
            string type = tokens[0];
            int id = int.Parse(tokens[1]);
            string firstName = tokens[2];
            string lastName = tokens[3];
            decimal salary = decimal.Parse(tokens[4]);

            ISoldier soldier = null;

            try
            {
                soldier = CreateSoldier(soldiers, tokens, type, id, firstName, lastName, salary);

                soldiers.Add(soldier);
            }
            catch { }
        }

        PrintSoldiers(soldiers);
    }

    private static void PrintSoldiers(List<ISoldier> soldiers)
    {
        foreach (var soldier in soldiers)
        {
            Console.WriteLine(soldier);
        }
    }

    private static ISoldier CreateSoldier(List<ISoldier> soldiers, string[] tokens, string type, int id, string firstName, string lastName, decimal salary)
    {
        ISoldier soldier;
        switch (type)
        {
            case "Private":
                soldier = new Private(id, firstName, lastName, salary);
                break;

            case "LeutenantGeneral":
                var leutenant = new LeutenantGeneral(id, firstName, lastName, salary);

                for (int i = 5; i < tokens.Length; i++)
                {
                    int privateId = int.Parse(tokens[i]);
                    ISoldier privateSoldier = soldiers.First(p => p.Id == privateId);
                    leutenant.AddPrivate(privateSoldier);
                }

                soldier = leutenant;
                break;

            case "Engineer":
                string engineerCorps = tokens[5];
                var engineer = new Engineer(id, firstName, lastName, salary, engineerCorps);

                for (int i = 6; i < tokens.Length; i++)
                {
                    string partName = tokens[i];
                    int hoursWorked = int.Parse(tokens[++i]);

                    IRepair repair = new Repair(partName, hoursWorked);
                    engineer.AddRepair(repair);

                }

                soldier = engineer;
                break;

            case "Commando":
                string commandoCorps = tokens[5];
                var commando = new Commando(id, firstName, lastName, salary, commandoCorps);

                for (int i = 6; i < tokens.Length; i++)
                {
                    string codeName = tokens[i];
                    string state = tokens[++i];

                    try
                    {
                        IMission mission = new Mission(codeName, state);
                        commando.AddMission(mission);
                    }
                    catch { }
                }

                soldier = commando;
                break;

            case "Spy":
                int codeNumber = (int)salary;
                soldier = new Spy(id, firstName, lastName, codeNumber);
                break;
            default:
                throw new ArgumentException("Invalid soldier type!");
        }

        return soldier;
    }
}

