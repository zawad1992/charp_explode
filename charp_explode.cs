using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        string input = "AB000101550022135552AB0002X899934300AB0003DDFYZZ3200";
        
        List<string> segments = new List<string> { "AB0001", "AB0002", "AB0003" };

        var result = SplitString(input, segments);

        for (int i = 0; i < result.Count; i++)
        {
            Console.WriteLine($"[{i}] = {result[i].Key}{result[i].Value}");
        }

        Console.WriteLine();

        foreach (var kvp in result)
        {
            Console.WriteLine($"[{kvp.Key}] = {kvp.Value}");
        }
    }

    public static List<KeyValuePair<string, string>> SplitString(string str, List<string> segments)
    {
        List<KeyValuePair<string, string>> result = new List<KeyValuePair<string, string>>();

        int currentIndex = 0;
        while (currentIndex < str.Length)
        {
            // Find the next segment in the string
            int nextIndex = str.Length;
            string matchedSegment = null;
            foreach (var segment in segments)
            {
                int foundIndex = str.IndexOf(segment, currentIndex);
                if (foundIndex != -1 && foundIndex < nextIndex)
                {
                    nextIndex = foundIndex;
                    matchedSegment = segment;
                }
            }

            if (matchedSegment == null)
            {
                // No segment found, exit the loop
                break;
            }

            int startOfValue = nextIndex + matchedSegment.Length;

            // Find the next nearest segment
            int endOfValue = str.Length;
            foreach (var segment in segments)
            {
                int foundIndex = str.IndexOf(segment, startOfValue);
                if (foundIndex != -1 && foundIndex < endOfValue)
                {
                    endOfValue = foundIndex;
                }
            }

            string value = str.Substring(startOfValue, endOfValue - startOfValue);
            result.Add(new KeyValuePair<string, string>(matchedSegment, value));

            currentIndex = endOfValue;
        }

        return result;
    }
}
