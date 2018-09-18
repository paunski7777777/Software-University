namespace Instagraph.App
{
    using AutoMapper;

    using System.Linq;

    using Instagraph.DataProcessor.Dtos.Export;
    using Instagraph.DataProcessor.Dtos.Import;
    using Instagraph.Models;

    public class InstagraphProfile : Profile
    {
        public InstagraphProfile()
        {
            CreateMap<PictureDto, Picture>();

            CreateMap<UserDto, User>()
                .ForMember(p => p.ProfilePicture, pp => pp.UseValue<Picture>(null));

            CreateMap<User, UserCommentsDto>()
                .ForMember(dto => dto.Username,
                           f => f.MapFrom(u => u.Username))
                .ForMember(dest => dest.MostComments,
                           opt => opt.MapFrom(src => src.Posts.Count == 0 ? 0 : src.Posts.Max(c => c.Comments.Count)));
        }
    }
}