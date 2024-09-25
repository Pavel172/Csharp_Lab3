using System;


namespace Task2
{

    public class Car: IEquatable<Car>
    {
        public string Name { get; set; }
        public string Engine { get; set; }
        public int MaxSpeed { get; set; }

        public Car(string Name, string Engine, int MaxSpeed)
        {
            this.Name = Name;
            this.Engine = Engine;
            this.MaxSpeed = MaxSpeed;
        }

        public bool Equals(Car car)
        {
            if (car.Name == Name && car.Engine == Engine && car.MaxSpeed == MaxSpeed) 
            {
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return $"{Name}";
        }
    }

    public interface IEquatable<Car>
    {
        public bool Equals(Car car);
    }

    public class CarsCatalog
    {
        public List <Car> Collection { get; set; }

        public CarsCatalog(params Car[] cars) 
        {
            Collection = new List <Car>();
            for (int i = 0; i < cars.Length; i++)
            {
                Collection.Add(cars[i]);
            }
        }
        public string this[int i]
        {
            get { return $"Name:{ToString()} Engine:{Collection[i].Engine}"; }
        }
    }
    public class Program
    {
        static void Main()
        {
            Car car1 = new Car("Ford", "EcoBoost", 210);
            Car car2 = new Car("Tesla", "3D1", 209);
            Car car3 = new Car("Ford", "EcoBoost", 210);
            CarsCatalog catalog = new CarsCatalog(car1, car2);
            if (car1.Equals(car2) == false) Console.WriteLine("Машины не идентичны");
            if (car1.Equals(car3) == true) Console.WriteLine("Машины идентичны");
        }
    }
}
