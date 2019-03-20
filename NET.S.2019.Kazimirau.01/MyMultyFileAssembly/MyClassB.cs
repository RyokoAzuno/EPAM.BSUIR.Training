using System;

namespace MyMultyFileAssembly
{
    /// <summary>
    /// A simple class for creating multy-file assembly
    /// Command prompt commnds
    /// To create a netmodule:                          >csc /t:module MyClassB.cs
    /// To create a multi-file assembly:                >csc /t:library /addmodule:MyClassA.netmodule /addmodule:MyClassB.netmodule /out:MyABMultyFileAssembly.dll
    /// To create a signed multi-file assembly:         >csc al /out:MyABCMultiFileAssemblySigned.dll MyClassA.netmodule MyClassA.netmodule MyClassB.netmodule MyClassB.netmodule /keyfile:MyPublicPrivateKey.snk
    /// To add assembly into GAC (as Administrator):    >gacutil -i MyABCMultiFileAssemblySigned.dll
    /// To remove assembly from GAC (as Administrator): >gacutil -u MyABCMultiFileAssemblySigned.dll
    /// </summary>
    public class MyClassB
    {
        public void Method() => Console.WriteLine($"{GetType().Name}");
    }
}
