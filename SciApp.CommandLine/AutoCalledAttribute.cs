using System;

namespace SciApp.CommandLine
{
    public class AutoCalledAttribute:Attribute
    {
        static AutoCalledAttribute()
        {
            Console.WriteLine("static method called");
        }
        public AutoCalledAttribute()
        {
            Console.WriteLine("constructor method called");
        }
         
    }
}