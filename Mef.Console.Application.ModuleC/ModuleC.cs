using System.Composition;
using Mef.Console.Application.ModuleBase;

namespace Mef.Console.Application.ModuleC
{
    [Export(typeof(IModule))]
    public class ModuleC : IModule
    {
        public void Initialize()
        {
            System.Console.WriteLine("Initilized " + nameof(ModuleC));
        }
    }
}
