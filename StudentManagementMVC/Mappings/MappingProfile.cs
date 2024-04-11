using AutoMapper;
using StudentManagementMVC.Dto;
using StudentManagementMVC.Models;

namespace StudentManagementMVC.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Student, StudentDetailsDto>().ForMember(c => c.FullName,
                opt => opt.MapFrom(x => string.Join(' ', x.FirstName, x.LastName)));

            CreateMap<CreateStudentDto, Student>().ReverseMap();
        }
    }
}