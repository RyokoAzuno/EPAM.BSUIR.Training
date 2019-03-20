using System;

namespace MyMultyFileAssembly
{
    /// <summary>
    /// A simple class for creating multy-file assembly
    /// Use command prompt command: >csc /t:module MyClassC.cs
    /// to create a netmodule.
    /// Use command prompt console: >csc /t:library /addmodule:MyClassA.netmodule /addmodule:MyClassB.netmodule /out:MyABMultyFileAssembly.dll
    /// to create a multi-file assembly.
    /// Use command prompt console: >csc al /out:MyABCMultiFileAssemblySigned.dll MyClassA.netmodule MyClassA.netmodule MyClassB.netmodule MyClassB.netmodule /keyfile:MyPublicPrivateKey.snk
    /// to create a signed multi-file assembly.
    /// </summary>
    public class MyClassC
    {
        public void Method() => Console.WriteLine($"{GetType().Name}");
    }
}
