using p5rpc.lib.interfaces;
using Reloaded.Mod.Interfaces;

namespace p5rpc.lib
{
    public class Exports : IExports
    {
        public Type[] GetTypes() => new[] { typeof(IFlowCaller) };
    }
}
