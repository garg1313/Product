using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product
{
    interface IRentable
    {
        public void Rent(int days);
    }
    internal class Vehicle
    {
        private int _VehicleId;
        private string _brand;
        private long _dailyrate;

        public int Vehicl0eId
        {
            get
            {
                return _VehicleId;

            }
        }
        public string Brand
        { get { return _brand; } }
        public long Dailyrate
        { get { return _dailyrate; } }

        public Vehicle(int id, string brand, long rate)
        {
            _VehicleId = id;
            _brand = brand;
            _dailyrate = rate;
        }
        public void Display()
        {
            Console.WriteLine($"Vehicle id={_VehicleId}\nBrand={_brand}\nTodayPrice={_dailyrate}");

        }
    }
    class Car : Vehicle, IRentable
    {
        public Car(int id, string brand, long rate) : base(id, brand, rate ){}
        public void Rent(int days) { }
    }


}
