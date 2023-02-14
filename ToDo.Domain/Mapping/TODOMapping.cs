using AutoMapper;
using ToDo.Domain.DBModel;
using ToDo.Domain.Model;
using ToDo.Domain.ViewModel;

namespace ToDo.Domain.Mapping
{
    public class TODOMapping : Profile
    {
        public TODOMapping()
        {
            CreateMap<TODO, TODOModel>()
                .ReverseMap();
            CreateMap<TODO, TODOViewModel>()
                .ForMember(a => a.UserName, b => b.MapFrom(b => b.User.Email))
                .ReverseMap();
        }
    }
}
