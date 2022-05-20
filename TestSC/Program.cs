using System;
using ServiceClient1;
using ServiceClient2;
namespace TestSC
{
    class Program
    {
        static void Main(string[] args)
        {
            Processor pr = new Processor();
            pr.LoadStudent();

            ClassProcessor c = new ClassProcessor();
            c.LoadClass();
            
        }
    }
}
