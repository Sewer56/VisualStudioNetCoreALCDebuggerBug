using System;
using HelloWorld;
using Reloaded.Memory.Pointers;

namespace MyPlugin
{
    internal class MyPlugin1 : IPlugin
    {
        public string GetName() => "My Plugin 1";
        public void RunSomeCode()
        {
            // Nothing Here.
        }

        // Just to ensure Reloaded.Memory is loaded.
        public FixedArrayPtr<int> FixedArrayPtr { get; } = new FixedArrayPtr<int>(0x0, 0); 
    }
}
