namespace HelloWorld
{
    using System;

    public static class Program
    {
        public static void Main(string[] args)
        {
            var c1 = new MyClass();
            Console.WriteLine($"Hello World! {c1.ReturnMessage()}");
        }
    }
}
