using AutoMapper;
using Project_PRN231.DTO;
using Project_PRN231.Models;

namespace Project_PRN231.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<Genre, GenresDTO>().ReverseMap();

            CreateMap<AssignTask, AssignTaskDTO>()
                .ForMember(dto => dto.Reporter, act => act.MapFrom(obj => obj.Reporter))
                .ForMember(dto => dto.Writer, act => act.MapFrom(obj => obj.Writer))
                .ForMember(dto => dto.Genre, act => act.MapFrom(obj => obj.Genre))
                .ForMember(dto => dto.Leader, act => act.MapFrom(obj => obj.Leader))
                .ForMember(dto => dto.ReportTasks, act => act.MapFrom(obj => obj.ReportTasks))
                .ForMember(dto => dto.WritingTasks, act => act.MapFrom(obj => obj.WritingTasks))
                .ReverseMap();

            CreateMap<WritingTask, WritingTaskDTO>()
                .ForMember(dto => dto.User, act => act.MapFrom(obj => obj.User))
                .ForMember(dto => dto.Task, act => act.MapFrom(obj => obj.Task))
                .ReverseMap();

            CreateMap<ReportTask, ReportTaskDTO>()
                .ForMember(dto => dto.User, act => act.MapFrom(obj => obj.User))
                .ForMember(dto => dto.Task, act => act.MapFrom(obj => obj.Task))
                .ReverseMap();
            CreateMap<User, UserDTO>()
                .ForMember(dto => dto.AssignTaskLeaders, act => act.MapFrom(obj => obj.AssignTaskLeaders))
                .ReverseMap();
        }
    }
}
