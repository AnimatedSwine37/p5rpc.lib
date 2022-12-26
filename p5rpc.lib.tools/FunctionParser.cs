using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace p5rpc.lib.tools
{
    internal class FunctionParser
    {
        internal void ParseFunctions(string libraryPath)
        {
            var files = Directory.GetFiles(libraryPath, "Functions.json", SearchOption.AllDirectories);

            using (var writer = new StreamWriter("functions.txt"))
            {
                using (var interfaceWriter = new StreamWriter("interfaces.txt"))
                {
                    foreach (var file in files)
                    {
                        string json = File.ReadAllText(file);
                        FlowFunction[] functions = JsonSerializer.Deserialize<FlowFunction[]>(json);
                        foreach (var function in functions)
                        {
                            string paramaters = function.Parameters == null ? "" : string.Join(", ", function.Parameters.Select(p => p.ToString()));
                            interfaceWriter.WriteLine($"public {function.ReturnType} {function.Name}({paramaters});");

                            string paramNames = function.Parameters == null ? "" : string.Join(", ", function.Parameters.Select(p => p.Name));
                            writer.WriteLine($"public {function.ReturnType} {function.Name}({paramaters}) " +
                                $"{{ {(function.ReturnType != "void" ? "return " : "")}Call{(function.ReturnType == "float" ? "Float" : "")}FlowFunction(FlowFunction.{function.Name}{(paramaters == "" ? "" : ", ")}{paramNames}); }}");
                        }
                    }
                }
            }
        }
    }
}
