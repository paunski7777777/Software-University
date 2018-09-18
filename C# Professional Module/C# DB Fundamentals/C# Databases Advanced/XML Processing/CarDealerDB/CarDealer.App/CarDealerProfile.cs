namespace CarDealer.App
{
    using AutoMapper;

    using CarDealer.App.DTOs.Import;
    using CarDealer.Models;

    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            CreateMap<SupplierDTO, Supplier>();
            CreateMap<PartDTO, Part>();
            CreateMap<CustomerDTO, Customer>();
            CreateMap<CarDTO, Car>();
        }
    }
}