using AutoMapper;
using Library.BLL.DTO;
using Library.DAL.Models;
using Library.User.DAL.Models;

namespace Library.BLL.Infrastructure
{
    public static class AutoMapperProfiles
    {
        public class AutoMapperProfile : Profile
        {
            public AutoMapperProfile()
            {
                CreateMap<BookToAddDTO, BookDTO>().ReverseMap();
                CreateMap<BookToEditDTO, BookDTO>().ReverseMap();
                CreateMap<BookModel, BookDTO>().ReverseMap();
                CreateMap<RentModel, RentDTO>().ForMember(rentDTO => rentDTO.BookDTO, o => o.MapFrom(rentModel => rentModel.BookModel)).ReverseMap();
                CreateMap<RentToCreateDTO, RentModel>().ReverseMap();
                CreateMap<RentToCloseDTO, RentModel>().ReverseMap();
                CreateMap<RentDTO, RentToCreateDTO>().ReverseMap();
                CreateMap<UserModel, UserDTO>().ReverseMap();
                CreateMap<UserModel, UserLoginedDTO>().ReverseMap();
                CreateMap<UserToRegisterDTO, UserModel>().ReverseMap();
                CreateMap<UserToLoginDTO, UserModel>().ReverseMap();
                CreateMap<UserLoginedDTO, UserModel>().ReverseMap();
            }
        }
    }
}
