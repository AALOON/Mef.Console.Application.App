using System.Composition;
using Mef.Console.Application.ModuleBase;

namespace Mef.Console.Application.ModuleA
{
    [Module(nameof(ModuleA))]
    [Export(typeof(IModule))]
    public class ModuleA : IModule
    {
        public void Initialize()
        {
            System.Console.WriteLine("Initilized " + nameof(ModuleA));
        }
    }
}
