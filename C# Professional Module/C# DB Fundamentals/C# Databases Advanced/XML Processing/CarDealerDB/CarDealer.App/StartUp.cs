namespace CarDealer.App
{
    using CarDealer.App.DTOs.Import;
    using CarDealer.Models;
    using CarDealer.Data;

    using AutoMapper;
    using System.IO;
    using System.Xml.Serialization;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            });

            var mapper = config.CreateMapper();
            // List<Supplier> suppliers = ImportSuppliers(mapper);
            // List<Part> parts = ImportParts(mapper);
            // List<Customer> customers = ImportCustomers(mapper);
            List<Car> cars = ImportCars(mapper);

            var db = new CarDealerContext();

            // db.Suppliers.AddRange(suppliers);
            // db.Parts.AddRange(parts);
            // db.Customers.AddRange(customers);
            db.Cars.AddRange(cars);

            db.SaveChanges();
        }

        private static List<Car> ImportCars(IMapper mapper)
        {
            var xmlCarsString = File.ReadAllText("../../../Xml/cars.xml");

            var serializer = new XmlSerializer(typeof(CarDTO[]), new XmlRootAttribute("cars"));

            var deserializedCars = (CarDTO[])serializer.Deserialize(new StringReader(xmlCarsString));

            var cars = new List<Car>();

            foreach (var carDto in deserializedCars)
            {
                if (!IsValid(carDto))
                {
                    continue;
                }

                var car = mapper.Map<Car>(carDto);

                cars.Add(car);
            }

            return cars;
        }

        private static List<Customer> ImportCustomers(IMapper mapper)
        {
            var xmlCustomersString = File.ReadAllText("../../../Xml/customers.xml");

            var serializer = new XmlSerializer(typeof(CustomerDTO[]), new XmlRootAttribute("customers"));

            var deserializedCustomers = (CustomerDTO[])serializer.Deserialize(new StringReader(xmlCustomersString));

            var customers = new List<Customer>();

            foreach (var customerDto in deserializedCustomers)
            {
                if (!IsValid(customerDto))
                {
                    continue;
                }

                var customer = mapper.Map<Customer>(customerDto);

                customers.Add(customer);
            }

            return customers;
        }

        private static List<Part> ImportParts(IMapper mapper)
        {
            var xmlPartsString = File.ReadAllText("../../../Xml/parts.xml");

            var serializer = new XmlSerializer(typeof(PartDTO[]), new XmlRootAttribute("parts"));

            var deserializedParts = (PartDTO[])serializer.Deserialize(new StringReader(xmlPartsString));

            var parts = new List<Part>();

            foreach (var partDto in deserializedParts)
            {
                if (!IsValid(partDto))
                {
                    continue;
                }

                var supplier = mapper.Map<Part>(partDto);

                var supplierId = new Random().Next(10, 21);

                supplier.SupplierId = supplierId;

                parts.Add(supplier);
            }

            return parts;
        }

        private static List<Supplier> ImportSuppliers(IMapper mapper)
        {
            var xmlSuppliersString = File.ReadAllText("../../../Xml/suppliers.xml");

            var serializer = new XmlSerializer(typeof(SupplierDTO[]), new XmlRootAttribute("suppliers"));

            var deserializedSuppliers = (SupplierDTO[])serializer.Deserialize(new StringReader(xmlSuppliersString));

            var suppliers = new List<Supplier>();

            foreach (var supplierDto in deserializedSuppliers)
            {
                if (!IsValid(supplierDto))
                {
                    continue;
                }

                var supplier = mapper.Map<Supplier>(supplierDto);

                suppliers.Add(supplier);
            }

            return suppliers;
        }

        public static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(obj, validationContext, validationResult, true);
        }
    }
}