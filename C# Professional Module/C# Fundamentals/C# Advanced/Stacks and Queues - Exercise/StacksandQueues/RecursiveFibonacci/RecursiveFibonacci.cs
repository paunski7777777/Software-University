using System;
class RecursiveFibonacci
{
    private static long[] memo;
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        memo = new long[n + 1];

        Console.WriteLine(GetFibonacci(n));
    }

    private static long GetFibonacci(long n)
    {
        if (n <= 2)
        {
            return 1;
        }

        if (memo[n] == 0)
        {
            memo[n] = GetFibonacci(n - 1) + GetFibonacci(n - 2);
        }

        return memo[n];
    }
}

