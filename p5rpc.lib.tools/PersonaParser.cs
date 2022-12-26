using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace p5rpc.lib.tools
{
    internal class PersonaParser
    {
        internal void ParsePersonas(string personasFile)
        {
            if (!File.Exists(personasFile))
            {
                Console.WriteLine($"File {personasFile} does not exist!");
                return;
            }
            using (var writer = new StreamWriter("personas.txt"))
            {
                List<string> existingNames = new List<string>();
                foreach (var line in File.ReadLines(personasFile))
                {
                    string[] parts = line.Split("\t");
                    string name = parts[2];
                    name = Regex.Replace(name, @"['()!?]", "");
                    name = Regex.Replace(name, @"[ -:/]", "_");
                    if (existingNames.Contains(name))
                    {
                        name = $"{name}_{parts[0]}";
                    }
                    existingNames.Add(name);
                    writer.WriteLine($"{name},");
                }
            }
        }
    }
}
