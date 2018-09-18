using System;
using System.Collections.Generic;
using System.Text;

public class Program
{
    public static void Main()
    {
        string[] trafficLightSignalsInput = Console.ReadLine().Split();
        int n = int.Parse(Console.ReadLine());

        List<TrafficLightSignal> trafficLightSignals = new List<TrafficLightSignal>();

        foreach (var tls in trafficLightSignalsInput)
        {
            Enum.TryParse(tls, out TrafficLightSignal trafficLightSignal);
            trafficLightSignals.Add(trafficLightSignal);
        }

        var sb = new StringBuilder();

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < trafficLightSignals.Count; j++)
            {
                var currentTrafficLightSignal = trafficLightSignals[j];
                currentTrafficLightSignal = SwitchTrafficLightSignal(currentTrafficLightSignal);
                trafficLightSignals[j] = currentTrafficLightSignal;

                sb.Append($"{currentTrafficLightSignal} ");
            }

            sb.AppendLine();
        }

        string result = sb.ToString().Trim();
        Console.WriteLine(result);
    }

    private static TrafficLightSignal SwitchTrafficLightSignal(TrafficLightSignal currentTrafficLightSignal)
    {
        var length = Enum.GetNames(typeof(TrafficLightSignal)).Length;
        var index = (int)currentTrafficLightSignal;
        currentTrafficLightSignal = (TrafficLightSignal)((index + 1) % length);

        return currentTrafficLightSignal;
    }
}