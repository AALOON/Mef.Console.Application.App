using System.Composition;
using Mef.Console.Application.ModuleBase;

namespace Mef.Console.Application.ModuleB
{
    [Module(nameof(ModuleB))]
    [Export(typeof(IModule))]
    public class ModuleB : IModule
    {
        [ImportingConstructor]
        public ModuleB(IService service)
        {
            service.DoJob(nameof(ModuleB));
        }
        public void Initialize()
        {
            System.Console.WriteLine("Initilized " + nameof(ModuleB));
        }
    }
}
