using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace p5rpc.lib.tools
{
    internal class ItemParser
    {
        internal void ParseItems(string itemsFile, int offset)
        {
            if (!File.Exists(itemsFile))
            {
                Console.WriteLine($"File {itemsFile} does not exist!");
                return;
            }
            using (var writer = new StreamWriter("items.txt"))
            {
                List<string> existingNames = new List<string>();
                foreach (var line in File.ReadLines(itemsFile))
                {
                    string[] parts = line.Split("\t");
                    int index = int.Parse(parts[0].TrimStart('0').Length == 0 ? "0" : parts[0].TrimStart('0'), NumberStyles.Any) + offset;
                    string name = parts[2];
                    name = Regex.Replace(name, @"['()!?.]", "");  
                    name = Regex.Replace(name, @"[ \-:/]", "_");
                    name = name.Replace("%", "_Percent");
                    name = name.Replace("+", "_Plus");
                    if (offset == 0x6000)
                        name += "_Card";
                    if (existingNames.Contains(name))
                    {
                        name = $"{name}_{index}";
                    }
                    if (Regex.IsMatch(name, @"^\d"))
                        name = "_" + name;
                    existingNames.Add(name);
                    writer.WriteLine("/// <summary>");
                    if (parts.Length > 3 && parts[3] != "")
                    {
                        if (offset == 0 || offset == 0x7000 || offset == 0x8000)
                            writer.WriteLine($"/// Useable by {parts[3]}");
                        else
                            writer.WriteLine($"/// {parts[3]} - {parts[4]}");
                    }
                    else
                    {
                        writer.WriteLine("/// ");
                    }
                    writer.WriteLine("/// </summary>");
                    writer.WriteLine($"{name} = {index},");
                }
            }

        }
    }
}
