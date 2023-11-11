# String Segment Splitter

## Introduction
This C# program is designed to split a given string into segments based on a predefined list of segment identifiers. It's particularly useful for parsing strings where certain markers or identifiers denote the start of a new segment.

## Prerequisites
- .NET Framework or .NET Core
- A C# compiler (Visual Studio, VS Code with C# extension, etc.)

## Installation
1. Clone the repository or download the source code.
2. Open the solution in your preferred C# development environment.
3. Ensure that all dependencies are correctly installed and referenced.

## Usage
To use the String Segment Splitter:
1. Define the input string that needs to be split.
2. Create a list of string segments that the program will look for in the input string.
3. Call the `SplitString` method, passing the input string and the list of segments.
4. The method returns a list of `KeyValuePair<string, string>`, where each key-value pair represents a segment identifier and its corresponding value in the input string.

### Example
Here's a quick example of how to use the program:

```csharp
using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        string input = "AB000101550022135552AB0002X899934300AB0003DDFYZZ3200";
        List<string> segments = new List<string> { "AB0001", "AB0002", "AB0003" };

        var result = SplitString(input, segments);

        foreach (var kvp in result)
        {
            Console.WriteLine($"[{kvp.Key}] = {kvp.Value}");
        }
    }

    // ... (Include the SplitString method here)
}
