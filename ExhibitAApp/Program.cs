using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        string inputPath = "/workspaces/Client-Song-Analysis/exhibitA-input.csv";
        string outputPath = "output.csv";

        // Dictionary to hold: clientId -> set of distinct songIds on 10/08/2016
        Dictionary<string, HashSet<string>> clientSongs = new();

        var dateFormat = new[] { "dd/MM/yyyy", "dd/MM/yyyy HH:mm:ss" };
        DateTime targetDate = new DateTime(2016, 8, 10);

        foreach (var line in File.ReadLines(inputPath).Skip(1)) // Skip header
        {
            var parts = line.Split('\t');
            if (parts.Length != 4) continue;

            string songId = parts[1].Trim();
            string clientId = parts[2].Trim();
            string playTs = parts[3].Trim();

            if (DateTime.TryParseExact(playTs, dateFormat, CultureInfo.InvariantCulture,
                                       DateTimeStyles.None, out DateTime playDate))
            {
                if (playDate.Date == targetDate)
                {
                    if (!clientSongs.ContainsKey(clientId))
                        clientSongs[clientId] = new HashSet<string>();

                    clientSongs[clientId].Add(songId);
                }
            }
        }

        // Dictionary: distinct play count -> number of clients
        Dictionary<int, int> playDistribution = new();

        foreach (var entry in clientSongs)
        {
            int distinctCount = entry.Value.Count;
            if (!playDistribution.ContainsKey(distinctCount))
                playDistribution[distinctCount] = 0;

            playDistribution[distinctCount]++;
        }

        // Write result
        using (var writer = new StreamWriter(outputPath))
        {
            writer.WriteLine("DISTINCT_PLAY_COUNT,CLIENT_COUNT");
            foreach (var kvp in playDistribution.OrderBy(kvp => kvp.Key))
            {
                writer.WriteLine($"{kvp.Key},{kvp.Value}");
            }
        }

        Console.WriteLine($"Output saved to {outputPath}");
    }
}
