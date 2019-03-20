using MyMultyFileAssembly;
using System;

namespace MyMultyFileAssemblyClient
{
    /// <summary>
    /// A client for testing my signed/not multy-file
    /// assembly (MyABCMultiFileAssembly.dll - not signed ;MyABCMultiFileAssemblySigned.dll - signed).
    /// To test it, you have to add a reference to MyABCMultiFileAssemblySigned.dll or MyABCMultiFileAssembly.dll(!!!NOT TO A PROJECT!!!)
    /// from MyMultiFileAssembly project.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            MyClassA a = new MyClassA();
            a.Method();

            MyClassB b = new MyClassB();
            b.Method();

            MyClassC c = new MyClassC();
            c.Method();

            Console.ReadLine();
        }
    }
}
