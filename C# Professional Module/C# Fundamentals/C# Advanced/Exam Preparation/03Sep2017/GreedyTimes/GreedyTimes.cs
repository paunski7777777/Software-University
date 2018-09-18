using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class GreedyTimes
{
    static void Main()
    {
        long capacity = long.Parse(Console.ReadLine());
        string[] items = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        var gold = new Dictionary<string, long>();
        long goldQuantity = 0;

        var gem = new Dictionary<string, long>();
        long gemQuantity = 0;

        var cash = new Dictionary<string, long>();
        long cashQuantity = 0;

        for (int i = 0; i < items.Length; i += 2)
        {
            string itemType = items[i];
            long itemAmount = long.Parse(items[i + 1]);

            string item = GetItemType(itemType);

            bool canInsertItem = CanPutItemInBag(item, itemAmount, capacity, goldQuantity, gemQuantity, cashQuantity);

            if (item == "invalid" || !canInsertItem)
            {
                continue;
            }

            switch (item)
            {
                case "Gold":
                    InsertItem(gold, itemType, itemAmount);
                    goldQuantity += itemAmount;
                    break;
                case "Gem":
                    InsertItem(gem, itemType, itemAmount);
                    gemQuantity += itemAmount;
                    break;
                case "Cash":
                    InsertItem(cash, itemType, itemAmount);
                    cashQuantity += itemAmount;
                    break;
            }
        }

        if (gold.Any())
        {
            Console.WriteLine(PrintBag(gold, "Gold", goldQuantity));

            if (gem.Any())
            {
                Console.WriteLine(PrintBag(gem, "Gem", gemQuantity));

                if (cash.Any())
                {
                    Console.WriteLine(PrintBag(cash, "Cash", cashQuantity));
                }
            }
        }
    }

    private static string PrintBag(Dictionary<string, long> bag, string item, long total)
    {
        var sb = new StringBuilder();

        sb.AppendLine($"<{item}> ${total}");

        var ordered = bag.OrderByDescending(x => x.Key).ThenBy(x => x.Value);

        foreach (var o in ordered)
        {
            sb.AppendLine($"##{o.Key} - {o.Value}");
        }

        string result = sb.ToString().TrimEnd();

        return result;
    }

    private static void InsertItem(Dictionary<string, long> bag, string itemType, long itemAmount)
    {
        if (!bag.ContainsKey(itemType))
        {
            bag[itemType] = 0;
        }

        bag[itemType] += itemAmount;
    }

    private static bool CanPutItemInBag(string itemType, long itemAmount, long capacity, long goldQuantity, long gemQuantity, long cashQuantity)
    {
        long total = goldQuantity + gemQuantity + cashQuantity;

        if (capacity < total + itemAmount)
        {
            return false;
        }

        switch (itemType)
        {
            case "Gold":
                return true;

            case "Gem":
                gemQuantity += itemAmount;
                return gemQuantity <= goldQuantity;

            case "Cash":
                cashQuantity += itemAmount;
                return cashQuantity <= gemQuantity;
        }

        return false;
    }

    private static string GetItemType(string itemType)
    {
        if (itemType.Length == 3)
        {
            return "Cash";
        }

        if (itemType.ToLower().EndsWith("gem"))
        {
            return "Gem";
        }

        if (itemType.ToLower() == "gold")
        {
            return "Gold";
        }

        return "invalid";
    }
}

