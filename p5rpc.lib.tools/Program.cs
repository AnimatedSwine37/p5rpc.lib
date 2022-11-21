using p5rpc.lib.tools;
using System.Text.Json;

if (args.Length == 0)
{
    Console.WriteLine("Usage: p5rpc.lib.tools <path to script compiler libraries folder>");
    return;
}

var files = Directory.GetFiles(args[0], "Functions.json", SearchOption.AllDirectories);
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