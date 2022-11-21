using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p5rpc.lib.tools
{
    public class FlowFunction
    {
        public string Index { get; set; }
        public string ReturnType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Parameter[]? Parameters { get; set; }
        public string Comment { get; set; }

        public FlowFunction(string Index, string ReturnType, string Name, string Description, Parameter[]? Parameters, string Comment)
        {
            this.Index = Index;
            this.ReturnType = ReturnType;
            this.Name = Name;
            this.Description = Description;
            this.Parameters = Parameters;
            this.Comment = Comment;
        }
    }

    public class Parameter
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Parameter(string Type, string Name, string Description)
        {
            this.Type = Type;
            this.Name = Name;
            this.Description = Description;
        }

        public override string ToString()
        {
            return $"{Type} {Name}";
        }
    }
}
