using System.Composition;

namespace Mef.Console.Application.App
{
    [Export(typeof(ModuleBase.IService))]
    public class InjectService : ModuleBase.IService
    {
        public InjectService()
        {
            System.Console.WriteLine("Initilized " + nameof(InjectService));
        }

        public void DoJob(string str)
        {
            System.Console.WriteLine(nameof(InjectService) + " -> " + str);
        }
    }
}
