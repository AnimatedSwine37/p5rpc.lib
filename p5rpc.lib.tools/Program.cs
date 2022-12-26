using p5rpc.lib.tools;
using System.Text.Json;

if (args.Length == 0)
{
    Console.WriteLine("Usage: p5rpc.lib.tools <function>");
    Console.WriteLine("Valid functions: functionParse, skillsParse, itemsParse, personasParse");
    return;
}

switch (args[0])
{
    case "functionParse":
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: p5rpc.lib.tools functionParse <path to script compiler libraries folder>");
            return;
        }

        new FunctionParser().ParseFunctions(args[1]);
        break;
    case "skillsParse":
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: p5rpc.lib.tools skillsParse <path to tab seperated skills table file>");
        }
        new SkillsParser().ParseSkills(args[1]);
        break;
    case "personasParse":
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: p5rpc.lib.tools personasParse <path to tab seperated persona table file>");
        }
        new PersonaParser().ParsePersonas(args[1]);
        break;
    case "itemsParse":
        if (args.Length < 3)
        {
            Console.WriteLine("Usage: p5rpc.lib.tools skillsParse <path to tab seperated items table file> <items start index>");
            return;
        }
        new ItemParser().ParseItems(args[1], int.Parse(args[2]));
        break;
    default:
        Console.WriteLine("Invalid function");
        Console.WriteLine("Valid functions: functionParse, skillsParse, itemsParse, personasParse");
        break;
}