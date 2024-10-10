using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalManagementSystem
{
    public class Car
    {
   

        public int CarId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public decimal RentalPrice { get; set; }
        public Car(int carId, string brand, string model, decimal rentalPrice)
        {
            CarId = carId;
            Brand = brand;
            Model = model;
            RentalPrice = rentalPrice;
        }

        public override string ToString()
        {
            return $"ID: {CarId}, Brand: {Brand}, Model: {Model}, RentalPrice: {RentalPrice}";
        }
    }
}
