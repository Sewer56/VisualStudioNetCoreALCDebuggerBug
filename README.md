# Visual Studio Debugger Bug

[Bug Report](https://developercommunity.visualstudio.com/content/problem/864954/vs2019-debugger-unable-to-select-correct-net-core.html)

This repository hosts a simple reproduction for a specific bug I found while working on [Reloaded-II](https://github.com/Reloaded-Project/Reloaded-II) Mod Loader. The bug consists of AssemblyLoadContext(s) and Visual Studio debugger's inability of picking the correct module for the current ALC while debugging.

### The Bug: Summarized

1. Create an AssemblyLoadContext. In the ALC, load an outdated version of a library.
2. Create a second AssemblyLoadContext. In the second ALC, somewhere in code, return a value from an API not available in the outdated version loaded by the other ALC.
3. Place a breakpoint after that API access, inspect the value.

**Expected Result:**
Returned value can be viewed as normal.

**Actual Result:**

 Name               | Value                                                       
 ------------------ | ------------------------------------------------------------
 integerAsReference | error CS7069: Reference to type 'RefPointer<>' claims it is defined in 'Reloaded.Memory', but it could not be found |      |

Works with any external library.

The expression evaluator is *completely broken*, you cannot query or modify any variable anywhere. Watch list does not work, autos and locals are empty, etc.

### Using the Reproduction
1. Open `hello-world.sln`.
2. Build Solution.
3. Breakpoint in `MyPlugin2.cs`, variable `breakpointMe`.
4. Try to inspect `integerAsReference`.

### Disclaimer(s)
The reproduction is a modified version of the `hello world` example of the [DotNetCorePlugins](https://github.com/natemcmaster/DotNetCorePlugins) library by Nate McMaster. I'm also a contributor of said library.
