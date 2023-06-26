using AutoMapper;
using Prueba.Model;
using Prueba.Model.Dto;


namespace SchoolAPI
{
    public class MappingConfig: Profile
    {
        public MappingConfig()
        {


            CreateMap<Libro, LibroDto>().ReverseMap();
            CreateMap<Libro, LibroCreateDto>().ReverseMap();
            CreateMap<Libro, LibroUpdateDto>().ReverseMap();


            CreateMap<Autor, AutorDto>().ReverseMap();
            CreateMap<Autor, AutorCreateDto>().ReverseMap();
            CreateMap<Autor, AutorUpdateDto>().ReverseMap();
        }

    }
}
