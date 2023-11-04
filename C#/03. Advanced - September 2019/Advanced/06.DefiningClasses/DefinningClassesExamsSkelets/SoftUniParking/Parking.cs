using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
        private List<Car> cars;
        private int capacity;

        public Parking(int capacity)
        {
            this.cars = new List<Car>();
            this.Capacity = capacity;
        }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }
            private set
            {
                this.capacity = value;
            }
        }

        public int Count => this.cars.Count;

        public string AddCar(Car car)
        {
            bool isCarAlreadyAdded = this.cars.Any(x => x.RegistrationNumber == car.RegistrationNumber);
            if (isCarAlreadyAdded)
            {
                return "Car with that registration number, already exists!";
            }

            bool isFreeSpace = this.cars.Count + 1 <= this.Capacity;
            if (!isFreeSpace)
            {
                return "Parking is full!";
            }

            this.cars.Add(car);

            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
        }

        public string RemoveCar(string registrationNumber)
        {
            bool isCarValid = this.cars.Any(x => x.RegistrationNumber == registrationNumber);
            if (!isCarValid)
            {
                return "Car with that registration number, doesn't exist!";
            }

            int indexCar = this.cars.FindIndex(x => x.RegistrationNumber == registrationNumber);
            this.cars.RemoveAt(indexCar);

            return $"Successfully removed {registrationNumber}";
        }

        public Car GetCar(string registrationNumber)
        {
            Car carToReturn = this.cars
                .Where(x => x.RegistrationNumber == registrationNumber)
                .FirstOrDefault();

            return carToReturn;
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (string currentNumber in registrationNumbers)
            {
                bool isFound = this.cars.Any(x => x.RegistrationNumber == currentNumber);
                if (!isFound)
                {
                    continue;
                }

                int indexCar = this.cars.FindIndex(x => x.RegistrationNumber == currentNumber);
                this.cars.RemoveAt(indexCar);
            }
        }
    }
}
