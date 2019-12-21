using System;
using HelloWorld;
using Reloaded.Memory.Interop;
using Reloaded.Memory.Pointers;

namespace MyPlugin2
{
    internal unsafe class MyPlugin2 : IPlugin
    {
        public string GetName() => "My Plugin 2";
        public void RunSomeCode()
        {
            ref var integerAsReference = ref RefPointer.TryDereference(out bool success);
            int breakpointMe = 5;
            
            // The other AssemblyLoadContext loaded an outdated version of the Reloaded.Memory library
            // That library does not have the RefPointer<> API.
            // If you breakpoint here, you get a nasty CS7069.
        }

        public static Pinnable<int> PinnedInt { get; } = new Pinnable<int>(42);

        // This API is not available in the outdated version of Reloaded.Memory in other AssemblyLoadContext.
        public static RefPointer<int> RefPointer { get; } = new RefPointer<int>(PinnedInt.Pointer, 1);
    }
}
