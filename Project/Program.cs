using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class Car
    {
        public string name { get; set; }
        public double fuel { get; set; }
        public bool started { get; set; }
        public Car(string jmeno, int palivo)
        {
            name = jmeno;
            fuel = palivo;
            started = false;
        }
        public void StartEngine()
        {
            started = true;
            Console.WriteLine("Started!");
        }
        public void StopEngine()
        {
            started = false;
            Console.WriteLine("Stoped!");
        }
        public void Drive(double distance)
        {
            double fuelComsuption = distance * 0.1;
            if (fuelComsuption < fuel && started == true)
            {
                fuel -= fuelComsuption;
                Console.WriteLine($"Auto {name} se pohybovalo o {distance} km.");
            }
            else if (started == true)
            {
                Console.Write($"Není dostatek benzínu v nádrži pro cestu {distance} km.");
            }
            else
            {
                Console.WriteLine("Není nastartováno");
            }
        }
        public void ReFuel(double fuelAmount)
        {
            fuel += fuelAmount;
            Console.WriteLine($"Dolil jsi {fuelAmount} litrů benzínu do auta {name}.");
        }
    }
    class Garage
    {
        public List<Car> cars;
        public Garage()
        {
            cars = new List<Car>();
        }
        public void NewCar (Car car)
        {
            cars.Add(car);
        }
     }
    internal class Program
    {
        static void Main(string[] args)
        {
            Garage myGarage =  new Garage();
            Car car1 = new Car("Škoda", 70);
            Car car2 = new Car("Ford", 60);
            Car car3 = new Car("Fabia", 80);
            myGarage.NewCar(car1);
            myGarage.NewCar(car2);
            myGarage.NewCar(car3);
            int i = 1;
            string command = "";
            while (command != "finish")
            {
                Console.Clear();
                foreach (Car car in myGarage.cars)
                {
                    Console.WriteLine($"Auto {car.name} je {i}. v garáži");
                    i++;
                }
                i = 0;
                Console.WriteLine();
                posibleCommands();
                Console.WriteLine();
                command = Console.ReadLine();
                doCommand(command, car1, car2, car3);
                Console.ReadKey();
            }
            Console.ReadKey();
        }
        public static void posibleCommands()
        {
            Console.WriteLine("Pro manipulaci s autem napiš jeho číslo a co chceš udělat. (např. 1 Start)");
            Console.WriteLine("Start = nastartuje motor auta");
            Console.WriteLine("Stop = zastaví motor auta");
            Console.WriteLine("Natankovat = Doplní benzín");
            Console.WriteLine("Jet = Ujede určitou vzdálenost");
        }
        public static void doCommand(string command, Car car1, Car car2, Car car3) 
        {
            if (command == "1 Start") { car1.StartEngine(); }
            else if (command == "2 Start") { car2.StartEngine(); }
            else if (command == "3 Start") { car3.StartEngine(); }
            else if (command == "1 Stop") { car1.StopEngine(); }
            else if (command == "2 Stop") { car2.StopEngine(); }
            else if (command == "3 Stop") { car3.StopEngine(); }
            else if (command == "1 Natankovat")
            {
                Console.WriteLine("Kolik chceš natankovat?");
                car1.ReFuel(Convert.ToInt32(Console.ReadLine()));
            }
            else if (command == "2 Natankovat")
            {
                Console.WriteLine("Kolik chceš natankovat?");
                car2.ReFuel(Convert.ToInt32(Console.ReadLine()));
            }
            else if (command == "3 Natankovat")
            {
                Console.WriteLine("Kolik chceš natankovat?");
                car3.ReFuel(Convert.ToInt32(Console.ReadLine()));
            }
            else if (command == "1 Jet")
            {
                Console.WriteLine("Jak daleko chceš jet?");
                car1.Drive(Convert.ToInt32(Console.ReadLine()));
            }
            else if (command == "2 Jet")
            {
                Console.WriteLine("Jak daleko chceš jet?");
                car2.Drive(Convert.ToInt32(Console.ReadLine()));
            }
            else if (command == "3 Jet")
            {
                Console.WriteLine("Jak daleko chceš jet?");
                car3.Drive(Convert.ToInt32(Console.ReadLine()));
            }
        }   
    }
}
