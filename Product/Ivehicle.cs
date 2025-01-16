using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product
{
    interface IVehicle
    {
        void StartEngine(); 
        void StopEngine();

    }
    class Car1 : IVehicle

    {
        public void StartEngine()
        {
            Console.WriteLine("Audi Welcomes you .Please use seat belt for safety");
            Console.WriteLine("Please Wait for few seconds");
            Thread.Sleep(10000);
            Console.WriteLine("Audi A7 Advance Mode Activated");
        }
        public void StopEngine()
        {
            Console.WriteLine("Engine ShuDown. See you next time");
        }
    }
    class Bike : IVehicle
    {
        public void StartEngine()
        {
            Console.WriteLine("KTM Welcomes you");
            Thread.Sleep(10000);
            Console.WriteLine("Adavance Racing Activated");
        }
        public void StopEngine()
        {
            Console.WriteLine("Engine off.. See you next time buddy");

        }
    }
    class program
    {
        /*public static void Main(string[] args)
        {
            Car1 Audi = new Car1();
            Audi.StartEngine();
            Audi.StopEngine();
            Bike Ktm = new Bike();
            Ktm.StartEngine();
            Ktm.StopEngine();

        }*/
    }
}