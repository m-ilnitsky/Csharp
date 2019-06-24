using System;
using Task08_PrivateAssembly_dll;

namespace Task08_PrivateAssembly_app
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
