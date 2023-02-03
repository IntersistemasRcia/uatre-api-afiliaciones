using AutoMapper;
using CleanArchitecture.Application.Features.Actividad.Queries.GetActividadList;
using CleanArchitecture.Application.Features.Afiliado.Commands.CreateAfiliado;
using CleanArchitecture.Application.Features.Afiliado.Queries;
using CleanArchitecture.Application.Features.Provincia.Queries.GetNacionalidadesList;
using CleanArchitecture.Application.Features.Provincia.Queries.GetProvinciasList;
using CleanArchitecture.Application.Features.Puesto.Queries;
using CleanArchitecture.Application.Features.Seccional.Queries;
using CleanArchitecture.Application.Features.Sexo.Queries;
using CleanArchitecture.Domain;

namespace CleanArchitecture.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Sexo, SexoVm>();
            CreateMap<Actividad, ActividadVm>();
            CreateMap<Afiliado, AfiliadoVm>()
                .ForMember(a => a.EstadoSolicitud, x => x.MapFrom(b => b.EstadoSolicitud.Descripcion))
                .ForMember(a => a.Sexo, x => x.MapFrom(b => b.Sexo.Codigo))
                .ForMember(a => a.Actividad, x => x.MapFrom(b => b.Actividad.Descripcion))
                .ForMember(a => a.Seccional, x => x.MapFrom(b => b.Seccional.Descripcion))
                .ForMember(a => a.Provincia, x => x.MapFrom(b => b.Seccional.SeccionalLocalidad.Select(y => y.Localidad.Provincia.Nombre)))
                .ForMember(a => a.Puesto, x => x.MapFrom(b => b.Puesto.Descripcion))
                ;
            CreateMap<Puesto, PuestoVm>();
            CreateMap<Seccional, SeccionalVm>();
            CreateMap<Provincia, ProvinciaVm>();
            CreateMap<Nacionalidad, NacionalidadVm>();

            CreateMap<CreateAfiliadoCommand, Afiliado>();
        }
    }
}
