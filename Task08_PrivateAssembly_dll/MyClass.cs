namespace Task08_PrivateAssembly_dll
{
    public class MyClass
    {
        private const string Prefix = "MyClass(PrivateAssembly):";
        private string _name;

        public MyClass(string name)
        {
            _name = Prefix + name;
        }

        public MyClass() : this("")
        {
        }

        public string Name
        {
            set => _name = Prefix + value;
            get => _name;
        }
    }
}
