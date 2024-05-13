using AutoMapper;
using Microservices.Models;
using Microservices.Models.Dtos;

namespace Microservices.Mapper
{
    public class PatientsMapper: Profile
    {

        public PatientsMapper()
        {
            // Mapeo principal de Patient a PatientDto y viceversa
            //CreateMap<Patient, PatientDto>()
            //    .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            //    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            //    .ReverseMap();

            //// Mapeos para tipos complejos
            //CreateMap<Email, EmailDto>().ReverseMap();
            //CreateMap<Name, NameDto>().ReverseMap();

            CreateMap<Patient, PatientDto>();
          
        }
    }
}
