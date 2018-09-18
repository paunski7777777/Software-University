
namespace StorageMaster.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Engine
    {
        private StorageMaster storageMaster;
        public bool IsRunning { get; set; }

        public Engine()
        {
            this.storageMaster = new StorageMaster();
            this.IsRunning = true; ;
        }

        public void Run()
        {

            while (IsRunning)
            {
                string input = Console.ReadLine();

                try
                {
                    this.ParseInput(input);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"ERROR: {e.Message}");
                }
                
            }
        }

        private void ParseInput(string input)
        {
            string[] tokens = input.Split();
            string command = tokens[0];

            if (command == "AddProduct")
            {
                string productType = tokens[1];
                double price = double.Parse(tokens[2]);

                Console.WriteLine(this.storageMaster.AddProduct(productType, price));
            }
            else if (command == "RegisterStorage")
            {
                string storageType = tokens[1];
                string storageName = tokens[2];

                Console.WriteLine(this.storageMaster.RegisterStorage(storageType, storageName));
            }
            else if (command == "SelectVehicle")
            {
                string storageName = tokens[1];
                int garageSlot = int.Parse(tokens[2]);

                Console.WriteLine(this.storageMaster.SelectVehicle(storageName, garageSlot));
            }
            else if (command == "LoadVehicle")
            {
                IEnumerable<string> productNames = new List<string>(tokens.Skip(1).ToList());

                Console.WriteLine(this.storageMaster.LoadVehicle(productNames));
            }
            else if (command == "SendVehicleTo")
            {
                string sourceName = tokens[1];
                int sourceGarageSlot = int.Parse(tokens[2]);
                string destinationName = tokens[3];

                Console.WriteLine(this.storageMaster.SendVehicleTo(sourceName, sourceGarageSlot, destinationName));
            }
            else if (command == "UnloadVehicle")
            {
                string storageName = tokens[1];
                int garageSlot = int.Parse(tokens[2]);

                Console.WriteLine(this.storageMaster.UnloadVehicle(storageName, garageSlot));
            }
            else if (command == "GetStorageStatus")
            {
                string storageName = tokens[1];

                Console.WriteLine(this.storageMaster.GetStorageStatus(storageName));
            }
            else if (command == "GetSummary")
            {
                string storageName = tokens[1]; ;

                Console.WriteLine(this.storageMaster.GetStorageStatus(storageName));
            }
            else if (command == "END")
            {
                Console.WriteLine(this.storageMaster.GetSummary());
                this.IsRunning = false;
            }
        }
    }
}
