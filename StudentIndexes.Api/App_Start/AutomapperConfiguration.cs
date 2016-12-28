using AutoMapper;
using StudentIndexes.Domain.DTOs;
using StudentIndexes.Domain.Models;

namespace StudentIndexes.Api
{
    public class AutomapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<UserDto, UserModel>();
                cfg.CreateMap<UserModel, UserDto>();
                cfg.CreateMap<StudentDto, StudentModel>();
                cfg.CreateMap<StudentModel, StudentDto>();
                cfg.CreateMap<GradeDto, GradeModel>();
                cfg.CreateMap<GradeModel, GradeDto>();
            });
        }
    }
}