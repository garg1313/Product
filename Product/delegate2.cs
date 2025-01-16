using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product
{
    public delegate void OnWeatherUpdate(string msg);
    interface IWeatherSensor
    {
        void ReadData();
    }

    internal class WeatherDevice
    {
        private int _deviceid;
        private string _location;
        public int DeviceID { get { return _deviceid; } }
        public string Location { get { return _location; } }
        public WeatherDevice(int deviceid, string location)
        {
            _deviceid = deviceid;
            _location = location;
        }
        public event OnWeatherUpdate OnWUP;
        public void details()
        {
            Console.WriteLine($"Device Id:- {_deviceid}\nLocation :-{Location}\n");


        }
        protected void RaiseWeatherAlert(string msg)
        {
            // Manually invoke the event
            if (OnWUP != null)
            {
                OnWUP.Invoke(msg);
            }
        }


    }
    class Thermometer : WeatherDevice, IWeatherSensor
    {
        private double temp;
        public Thermometer(int deviceid, string loc) : base(deviceid, loc)
        {
        }
        public void ReadData()
        {
            Random rand = new Random();
            temp = rand.Next(-10, 50);
            Console.WriteLine($"Temperature Reading: {temp}°C");
            if (temp > 40)
            {
                //OnWUP?.Invoke("Extreme Heat Alert: High Temperature Detected!");
                RaiseWeatherAlert("Extreme Heat Alert: High Temperature Detected!\n");
            }
            else if(temp<0){
                RaiseWeatherAlert("OH its to Cold");
            }
        }
    }
    class Barometer : WeatherDevice, IWeatherSensor
    {
        private double pressure;
        public Barometer(int deviceid, string loc) : base(deviceid, loc)
        {
        }

        public void ReadData()
        {
            Random rand = new Random();
            pressure = rand.Next(900, 1270);
            Console.WriteLine($"Pressure Reading: {pressure} hPa");
            if (pressure > 1050)
            {
                RaiseWeatherAlert("Storm Alert: Low Pressure Detected!\n");
               // OnWUP?.Invoke("Storm Alert: Low Pressure Detected!");
            }

        }
    }
        class pro
        {
            /*public  void DisplayAlert(string msg)
            {
                Console.WriteLine("ALERT: " + msg);
            }

            public static void Main(string[] args)
            {
                pro programInstance = new pro();
                Thermometer t1=new Thermometer(1200,"New York");
                Barometer b1 = new Barometer(1500, "London");
                t1.OnWUP += programInstance.DisplayAlert;
                b1.OnWUP += programInstance.DisplayAlert;
     
                t1.details();
                t1.ReadData();

                b1.details();
                b1.ReadData();*//*
            

            }*/
        }

}
    

