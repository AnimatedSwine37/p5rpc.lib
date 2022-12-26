using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace p5rpc.lib.tools
{
    internal class SkillsParser
    {
        internal void ParseSkills(string skillsFile)
        {
            if(!File.Exists(skillsFile))
            {
                Console.WriteLine($"File {skillsFile} does not exist!");
                return;
            }
            using (var writer = new StreamWriter("skills.txt"))
            {
                List<string> existingNames = new List<string>();
                foreach (var line in File.ReadLines(skillsFile))
                {
                    string[] parts = line.Split("\t");
                    string name = parts[2];
                    name = Regex.Replace(name, @"['()!]", "");
                    name = Regex.Replace(name, @"[ -:/]", "_");
                    if (existingNames.Contains(name))
                    {
                        name = $"{name}_{parts[0]}";
                    }
                    existingNames.Add(name);
                    writer.WriteLine("/// <summary>");
                    writer.WriteLine($"/// {parts[3]}");
                    writer.WriteLine("/// </summary>");
                    writer.WriteLine($"{name},");
                }
            }
        }
    }
}
