namespace SoftJail
{
    using AutoMapper;

    using SoftJail.Data.Models;
    using SoftJail.DataProcessor.ImportDto;

    public class SoftJailProfile : Profile
    {
        // Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE THIS CLASS
        public SoftJailProfile()
        {
            CreateMap<DepartmentDto, Department>();
            CreateMap<CellDto, Cell>();
        }
    }
}