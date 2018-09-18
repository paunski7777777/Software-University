using System;
using System.Linq;

class ParkingSystem
{
    static bool[][] parkingLot;
    static int columns;
    static void Main()
    {
        int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int rows = dimensions[0];
        columns = dimensions[1];

        parkingLot = new bool[rows][];

        string input;
        while ((input = Console.ReadLine()) != "stop")
        {
            int[] tokens = input.Split().Select(int.Parse).ToArray();
            int entryRow = tokens[0];
            int targetRow = tokens[1];
            int targetCol = tokens[2];

            if (IsSpotTaken(targetRow, targetCol))
            {
                targetCol = TryFindFreeSpot(targetRow, targetCol);
            }

            if (targetCol > 0)
            {
                MarkSpotAsTaken(targetRow, targetCol);

                int distance = Math.Abs(entryRow - targetRow) + targetCol + 1;

                Console.WriteLine(distance);
            }

            else
            {
                Console.WriteLine($"Row {targetRow} full");
            }
        }
    }

    private static void MarkSpotAsTaken(int targetRow, int targetCol)
    {
        if (parkingLot[targetRow] == null)
        {
            parkingLot[targetRow] = new bool[columns];
        }

        parkingLot[targetRow][targetCol] = true;
    }

    private static int TryFindFreeSpot(int targetRow, int targetCol)
    {
        int parkingColumn = 0;
        int bestDistance = 10001;

        for (int col = 1; col < columns; col++)
        {
            if (!parkingLot[targetRow][col])
            {
                int distance = Math.Abs(col - targetCol);

                if (distance < bestDistance)
                {
                    parkingColumn = col;
                    bestDistance = distance;
                }
            }
        }

        return parkingColumn;
    }

    private static bool IsSpotTaken(int targetRow, int targetCol)
    {
        return parkingLot[targetRow] != null && parkingLot[targetRow][targetCol];
    }
}

