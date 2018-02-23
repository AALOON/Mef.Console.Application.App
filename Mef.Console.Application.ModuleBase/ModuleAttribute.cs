using System;

namespace Mef.Console.Application.ModuleBase
{
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class ModuleAttribute : Attribute
    {
        public ModuleAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}
