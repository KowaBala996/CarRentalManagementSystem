using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalManagementSystem
{
    public class CarManager
    {
        public List<Car> Carslist = new List<Car>();

        public void CreateCar(int carId, string brand, string model, decimal rentalPrice)
        {
            Car car = new Car(carId,brand,model,rentalPrice);
            Carslist.Add(car);
            Console.WriteLine("Car add successfully");
        }
        public void ReadCars()
        {
            if (Carslist.Count != 0)
            {
                foreach (var car in Carslist)
                {
                    Console.WriteLine(car.ToString());
                }
            }else
            {
                Console.WriteLine("There are no car available");
            }
        }
        public void UpdateCar(int carId, string newbrand, string newmodel, decimal newrentalPrice) 
        {
            Car car=Carslist.FirstOrDefault(c => c.CarId == carId);
            if (car != null)
            {
                car.RentalPrice = newrentalPrice;
                car.Model = newmodel;
                car.Brand = newbrand;
                Console.WriteLine("Car update successfully");

            }else
            {
                Console.WriteLine("There are no car available");
            }


        }
        public void DeleteCar(int carId)
        {
            Car car = Carslist.FirstOrDefault(c => c.CarId == carId);
            if (car != null)
            {
                Carslist.Remove(car);
                Console.WriteLine("Car delete successfully");

            }
            else
            {
                Console.WriteLine("There are no car available");
            }


        }
        public decimal ValidateCarRentalPrice()
        {
            decimal price;
            while (true)
            {
                Console.WriteLine(" Enter the Rental price");
                if(decimal.TryParse(Console.ReadLine(), out price)&&price>0)
                {
                    return price;
                }
                Console.WriteLine("Invalid price!! please enter positive number value");
            }
           
        } 

    }
}
