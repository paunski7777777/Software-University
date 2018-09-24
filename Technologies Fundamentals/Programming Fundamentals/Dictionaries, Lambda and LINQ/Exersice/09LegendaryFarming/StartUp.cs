namespace _09LegendaryFarming
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var items = new SortedDictionary<string, int> { ["motes"] = 0, ["shards"] = 0, ["fragments"] = 0 };
            var junk = new SortedDictionary<string, int>();

            bool isObtained = false;

            while (!isObtained)
            {
                string[] input = Console.ReadLine().ToLower().Split();

                for (int i = 0; i < input.Length; i += 2)
                {
                    var material = input[i + 1];
                    var quantity = int.Parse(input[i]);

                    if (items.ContainsKey(material))
                    {
                        items[material] += quantity;

                        if (items.Values.Any(x => x >= 250))
                        {
                            items[material] -= 250;

                            string obtainedItem = string.Empty;

                            switch (material)
                            {
                                case "shards":
                                    obtainedItem = "Shadowmourne";
                                    break;
                                case "fragments":
                                    obtainedItem = "Valanyr";
                                    break;
                                case "motes":
                                    obtainedItem = "Dragonwrath";
                                    break;
                            }

                            isObtained = true;

                            Console.WriteLine($"{obtainedItem} obtained!");
                            break;
                        }
                    }
                    else
                    {
                        if (!junk.ContainsKey(material))
                        {
                            junk.Add(material, 0);
                        }

                        junk[material] += quantity;
                    }
                }
            }
            var remaining = items.OrderByDescending(x => x.Value).ThenBy(x => x.Key);

            foreach (var item in remaining)
            {
                var material = item.Key;
                var quantity = item.Value;

                Console.WriteLine($"{material}: {quantity}");
            }

            foreach (var item in junk)
            {
                var material = item.Key;
                var quantity = item.Value;

                Console.WriteLine($"{material}: {quantity}");
            }
        }
    }
}