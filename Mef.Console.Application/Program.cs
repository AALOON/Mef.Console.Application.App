using System;
using System.Collections.Generic;
using System.Composition;
using System.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;

namespace Mef.Console.Application.App
{
    public sealed class Program
    {
        private const string ModulesDirectory = "Modules";

        [ImportMany]
        private IEnumerable<ModuleBase.IModule> Modules { get; set; }
        private void Compose()
        {
            //Self Assembly
            var currentAssembly = Assembly.GetExecutingAssembly();

            //Reference assembly
            var referencedAssembly = typeof(ModuleC.ModuleC).Assembly;

            var executableLocation = currentAssembly.Location;
            var modulesLocation = Path.Combine(Path.GetDirectoryName(executableLocation), ModulesDirectory);

            //Filed Assemblies
            var outsideAssemblies = Directory.GetFiles(modulesLocation, "*.dll").Select(AssemblyLoadContext.Default.LoadFromAssemblyPath);

            var assemblies = outsideAssemblies.ToList();
            assemblies.Add(currentAssembly);
            assemblies.Add(referencedAssembly);

            var configuration = new ContainerConfiguration().WithAssemblies(assemblies);
            using (var container = configuration.CreateContainer())
            {
                Modules = container.GetExports<ModuleBase.IModule>();
            }
        }

        private static void TryShowModuleName(ModuleBase.IModule module)
        {
            if (module == null) return;

            var type = module.GetType();

            var tmp = Attribute.GetCustomAttribute(type, typeof(ModuleBase.ModuleAttribute)) as ModuleBase.ModuleAttribute;

            if(tmp!=null)
                System.Console.WriteLine("Trying to initilize module named: " + tmp.Name);
            else
                System.Console.WriteLine("Trying to initilize module typeof: " + type.Name);
        }

        private void Run()
        {
            Compose();
            foreach (var module in Modules)
            {
                TryShowModuleName(module);
                module.Initialize();
            }
        }
        

        static void Main(string[] args)
        {
            var p = new Program();
            p.Run();
            System.Console.ReadLine();
        }
    }
}
