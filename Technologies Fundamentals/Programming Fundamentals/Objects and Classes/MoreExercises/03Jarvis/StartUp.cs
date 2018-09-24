namespace _03Jarvis
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            long maximumEnergyCapacity = long.Parse(Console.ReadLine());
            string command = Console.ReadLine();

            Robot robot = new Robot();

            while (!command.Equals("Assemble!"))
            {
                string[] tokens = command.Split();

                string componentType = tokens[0];
                int energyConsumption = int.Parse(tokens[1]);

                if (componentType == "Head")
                {
                    Head head = new Head
                    {
                        EnergyConsumption = energyConsumption,
                        IQ = int.Parse(tokens[2]),
                        SkinMaterial = tokens[3]
                    };

                    if (robot.Head == null)
                    {
                        robot.Head = new List<Head>();
                    }

                    robot.Head.Add(head);
                }

                else if (componentType == "Torso")
                {
                    Torso torso = new Torso
                    {
                        EnergyConsumption = energyConsumption,
                        ProcessorSizeInCentimeters = double.Parse(tokens[2]),
                        HousingMaterial = tokens[3]
                    };

                    if (robot.Torso == null)
                    {
                        robot.Torso = new List<Torso>();
                    }

                    robot.Torso.Add(torso);
                }

                else if (componentType == "Arm")
                {
                    Arms arms = new Arms
                    {
                        EnergyConsumption = energyConsumption,
                        ArmReachDistance = int.Parse(tokens[2]),
                        CountOfFingers = int.Parse(tokens[3])
                    };

                    if (robot.Arms == null)
                    {
                        robot.Arms = new List<Arms>();
                    }

                    robot.Arms.Add(arms);
                }

                else if (componentType == "Leg")
                {
                    Legs legs = new Legs
                    {
                        EnergyConsumption = energyConsumption,
                        Strength = int.Parse(tokens[2]),
                        Speed = int.Parse(tokens[3])
                    };

                    if (robot.Legs == null)
                    {
                        robot.Legs = new List<Legs>();
                    }

                    robot.Legs.Add(legs);
                }

                command = Console.ReadLine();
            }

            if (robot.Arms == null)
            {
                robot.Arms = new List<Arms>();
            }
            if (robot.Legs == null)
            {
                robot.Legs = new List<Legs>();
            }
            if (robot.Head == null)
            {
                robot.Head = new List<Head>();
            }
            if (robot.Torso == null)
            {
                robot.Torso = new List<Torso>();
            }

            if (robot.Head.Count > 0 && robot.Torso.Count > 0 && robot.Arms.Count > 1 && robot.Legs.Count > 1)
            {
                long headEnergy = robot.Head.OrderBy(h => h.EnergyConsumption).First().EnergyConsumption;
                long torsoEnergy = robot.Torso.OrderBy(t => t.EnergyConsumption).First().EnergyConsumption;
                long armsEnergy = (robot.Arms.OrderBy(a => a.EnergyConsumption).First().EnergyConsumption
                    + robot.Arms.OrderBy(a => a.EnergyConsumption).Skip(1).Take(1).First().EnergyConsumption);
                long legsEnergy = (robot.Legs.OrderBy(l => l.EnergyConsumption).First().EnergyConsumption
                    + robot.Legs.OrderBy(l => l.EnergyConsumption).First().EnergyConsumption);

                long energy = headEnergy + torsoEnergy + armsEnergy + legsEnergy;

                if (energy > maximumEnergyCapacity)
                {
                    Console.WriteLine("We need more power!");
                }
                else
                {
                    Console.WriteLine("Jarvis:");
                    foreach (var h in robot.Head.OrderBy(e => e.EnergyConsumption).Take(1))
                    {
                        Console.WriteLine($"#Head:");
                        Console.WriteLine($"###Energy consumption: {h.EnergyConsumption}");
                        Console.WriteLine($"###IQ: {h.IQ}");
                        Console.WriteLine($"###Skin material: {h.SkinMaterial}");
                    }
                    foreach (var t in robot.Torso.OrderBy(e => e.EnergyConsumption).Take(1))
                    {
                        Console.WriteLine($"#Torso:");
                        Console.WriteLine($"###Energy consumption: {t.EnergyConsumption}");
                        Console.WriteLine($"###Processor size: {t.ProcessorSizeInCentimeters:f1}");
                        Console.WriteLine($"###Corpus material: {t.HousingMaterial}");
                    }
                    foreach (var a in robot.Arms.OrderBy(e => e.EnergyConsumption).Take(2))
                    {
                        Console.WriteLine($"#Arm:");
                        Console.WriteLine($"###Energy consumption: {a.EnergyConsumption}");
                        Console.WriteLine($"###Reach: {a.ArmReachDistance}");
                        Console.WriteLine($"###Fingers: {a.CountOfFingers}");
                    }
                    foreach (var l in robot.Legs.OrderBy(e => e.EnergyConsumption).Take(2))
                    {
                        Console.WriteLine($"#Leg:");
                        Console.WriteLine($"###Energy consumption: {l.EnergyConsumption}");
                        Console.WriteLine($"###Strength: {l.Strength}");
                        Console.WriteLine($"###Speed: {l.Speed}");
                    }
                }
            }

            else
            {
                Console.WriteLine("We need more parts!");
            }
        }
    }

    class Robot
    {
        public List<Arms> Arms { get; set; }
        public List<Legs> Legs { get; set; }
        public List<Torso> Torso { get; set; }
        public List<Head> Head { get; set; }
    }

    public class Arms
    {
        public int EnergyConsumption { get; set; }
        public int ArmReachDistance { get; set; }
        public int CountOfFingers { get; set; }
    }

    public class Legs
    {
        public int EnergyConsumption { get; set; }
        public int Strength { get; set; }
        public int Speed { get; set; }
    }

    public class Torso
    {
        public int EnergyConsumption { get; set; }
        public double ProcessorSizeInCentimeters { get; set; }
        public string HousingMaterial { get; set; }
    }

    public class Head
    {
        public int EnergyConsumption { get; set; }
        public int IQ { get; set; }
        public string SkinMaterial { get; set; }
    }
}