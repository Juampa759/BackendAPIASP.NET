using AutoMapper;
using PruebaFamiliar.DTO_s;
using PruebaFamiliar.DTOs;
using PruebaFamiliar.Entidades;

namespace PruebaFamiliar.Utilidades
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
            CreateMap<UsuarioCreacionDTO, Usuario>();
        }
    }
}
