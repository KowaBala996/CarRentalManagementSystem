﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager();
            Console.Clear();
            bool exit= false;
            SetConnection();

            while (!exit)
            {
                Console.WriteLine("Car Rental Management System:");
                Console.WriteLine("1. Add a Car");
                Console.WriteLine("2. View All Cars");
                Console.WriteLine("3. Update a Car");
                Console.WriteLine("4. Delete a Car");
                Console.WriteLine("5. Exit");
                Console.WriteLine("Choose an option");
                int option = int.Parse(Console.ReadLine());
                switch (option)
                {

                    case 1:
                        CreateCar(carManager);

                        break;
                    case 2:
                        carManager.ReadCars();
                        break;
                    case 3:
                        UpdateCar(carManager);
                        break;
                    case 4:
                        DeleteCar(carManager);
                        break;
                    case 5:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine();
                        break;
                }
            }
        }

        static void CreateCar(CarManager mngr)
        {
            Console.WriteLine("Enter the carid");
            int carid = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the Brand");
            string brand = Console.ReadLine();

            Console.WriteLine("Enter the Model");
            string model = Console.ReadLine();

            Console.WriteLine("Enter the RentalPrice");
            int rentalPrice = int.Parse(Console.ReadLine());
            mngr.CreateCar(carid, brand, model, rentalPrice);
        }
        static void UpdateCar(CarManager mngr)
        {
            Console.WriteLine("Enter the update carid");
            int upcarid = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the Brand");
            string upbrand = Console.ReadLine();

            Console.WriteLine("Enter the Model");
            string upmodel = Console.ReadLine();

            Console.WriteLine("Enter the RentalPrice");
            int uprentalPrice = int.Parse(Console.ReadLine());
            mngr.UpdateCar(upcarid, upbrand, upmodel, uprentalPrice);


        }
        static void DeleteCar(CarManager mngr)
        {
            Console.WriteLine("Enter the update carid");
            int deletecarid = int.Parse(Console.ReadLine());
            mngr.DeleteCar(deletecarid);
        }

        static void SetConnection()
        {
            string masterDbConnectionString = "Server=DESKTOP-HGNM0A1; Database=master; Trusted_Connection=True; TrustServerCertificate=True;";
            string carrentalDbConnectionString = "Server=DESKTOP-HGNM0A1; Database=CarRentalManagement; Trusted_Connection=True; TrustServerCertificate=True;";
            string dbQuery = @"
                    IF NOT EXISTS (SELECT * FROM sys.databases WHERE name='CarRentalManagement')
                    CREATE DATABASE CarRentalManagement;
                    ";

            string tableQuery = @"
                    IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Cars' AND xtype='U')
                    CREATE TABLE Cars(
                      CarId INT IDENTITY(1,1) PRIMARY KEY,  
                      Brand NVARCHAR(50) NOT NULL,
                      Model NVARCHAR(50) NOT NULL,
                      RentalPrice DECIMAL(10,2) NOT NULL
                    );";
            string insertQuery = @"
                    INSERT INTO Cars (Brand, Model, RentalPrice)
                    VALUES ('Honda' ,'Vessel', 10.00 );";

            using (SqlConnection connection = new SqlConnection(masterDbConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(dbQuery, connection))
                {
                    command.ExecuteNonQuery();
                    Console.WriteLine("Database created successfully");
                }
            }

            using (SqlConnection conn = new SqlConnection(carrentalDbConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(tableQuery, conn))
                {
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Table created successfully");
                }

                using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                {
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Sample data insert successfully");
                }

            }
            Console.ReadLine();


        }

    }
}
