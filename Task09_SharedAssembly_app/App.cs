using System;
using Task09_SharedAssembly_dll;

namespace Task09_SharedAssembly_app
{
    internal class App
    {
        private static void Main()
        {
            var myClass1 = new MyClass("myClass1");
            var myClass2 = new MyClass("myClass2");

            Console.WriteLine(myClass1.Name);
            Console.WriteLine(myClass2.Name);
        }
    }
}
