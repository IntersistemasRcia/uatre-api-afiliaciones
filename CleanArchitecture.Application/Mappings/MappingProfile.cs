using AutoMapper;
using CleanArchitecture.Application.Features.Actividad.Queries.GetActividadList;
using CleanArchitecture.Application.Features.Afiliado.Commands.CreateAfiliado;
using CleanArchitecture.Application.Features.Afiliado.Commands.UpdateAfiliado;
using CleanArchitecture.Application.Features.Afiliado.Queries;
using CleanArchitecture.Application.Features.AfiliadoEstadoSolicitud.Queries;
using CleanArchitecture.Application.Features.AfiliadoFormulariosAfiliacion.Commands.AfiliadoFormulariosAfiliacionCreate;
using CleanArchitecture.Application.Features.EstadoCivil.Queries;
using CleanArchitecture.Application.Features.EstadoSolicitud.Queries;
using CleanArchitecture.Application.Features.Notificaciones.Commands.NotificacionesCreate;
using CleanArchitecture.Application.Features.Notificaciones.Commands.NotificacionesUpdate;
using CleanArchitecture.Application.Features.Notificaciones.Queries;
using CleanArchitecture.Application.Features.Provincia.Queries.GetNacionalidadesList;
using CleanArchitecture.Application.Features.Provincia.Queries.GetProvinciasList;
using CleanArchitecture.Application.Features.Puesto.Queries;
using CleanArchitecture.Application.Features.RefLocalidad.Command.Create;
using CleanArchitecture.Application.Features.RefLocalidad.Command.Update;
using CleanArchitecture.Application.Features.RefLocalidad.Queries;
using CleanArchitecture.Application.Features.Seccional.Command.Create;
using CleanArchitecture.Application.Features.Seccional.Command.Update;
using CleanArchitecture.Application.Features.Seccional.Queries;
using CleanArchitecture.Application.Features.SeccionalAutoridad.Command.CreateSeccionalAutoridad;
using CleanArchitecture.Application.Features.SeccionalAutoridad.Command.UpdateSeccionalAutoridad;
using CleanArchitecture.Application.Features.SeccionalAutoridad.Queries;
using CleanArchitecture.Application.Features.SeccionalContacto.Command.Create;
using CleanArchitecture.Application.Features.SeccionalContacto.Command.UpdateSeccionalContacto;
using CleanArchitecture.Application.Features.SeccionalContacto.Queries;
using CleanArchitecture.Application.Features.SeccionalEstado.Commands.CreateSeccionalEstado;
using CleanArchitecture.Application.Features.SeccionalEstado.Commands.UpdateSeccionalEstado;
using CleanArchitecture.Application.Features.SeccionalEstado.Responses;
using CleanArchitecture.Application.Features.SeccionalLocalidad.Command.CreateSeccionalLocalidad;
using CleanArchitecture.Application.Features.SeccionalLocalidad.Command.UpdateRecordSeccionalLocalidad;
using CleanArchitecture.Application.Features.SeccionalLocalidad.Command.UpdateSeccionalLocalidad;
using CleanArchitecture.Application.Features.SeccionalLocalidad.Queries;
using CleanArchitecture.Application.Features.Sexo.Queries;
using CleanArchitecture.Application.Features.TipoDocumento.Queries;
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
                .ForMember(a => a.EstadoSolicitud, x => x.MapFrom(b => b.EstadoSolicitud!.Descripcion))
                .ForMember(a => a.Sexo, x => x.MapFrom(b => b.Sexo!.Descripcion))
                .ForMember(a => a.Actividad, x => x.MapFrom(b => b.Actividad!.Descripcion))
                .ForMember(a => a.Localidad, x => x.MapFrom(b => b.RefLocalidad!.Nombre))
                .ForMember(a => a.Seccional, x => x.MapFrom(b => b.Seccional!.Descripcion))
                .ForMember(a => a.SeccionalCodigo, x => x.MapFrom(b => b.Seccional!.Codigo))
                .ForMember(a => a.RefDelegacionId, x => x.MapFrom(b => b.Seccional!.RefDelegacionId))
                //.ForMember(a => a.RefDelegacionDescripcion, x => x.MapFrom(b => b.Seccional!.RefDelegacionDescripcion))
                .ForMember(a => a.ProvinciaId, x => x.MapFrom(b => b.RefLocalidad!.ProvinciaId))
                .ForMember(a => a.Provincia, x => x.MapFrom(b => b.RefLocalidad!.Provincia!.Nombre))
                .ForMember(a => a.Puesto, x => x.MapFrom(b => b.Puesto!.Descripcion))
                .ForMember(a => a.Nacionalidad, x => x.MapFrom(b => b.Nacionalidad!.Descripcion))
                //.ForMember(a => a.EmpresaCUIT, x => x.MapFrom(b => b.Empresa!.CUIT))
                //.ForMember(a => a.Empresa, x => x.MapFrom(b => b.Empresa!.RazonSocial))
                .ForMember(a => a.Nacionalidad, x => x.MapFrom(b => b.Nacionalidad!.Descripcion))
                .ForMember(a => a.EstadoCivil, x => x.MapFrom(b => b.EstadoCivil!.Descripcion))
                .ForMember(a => a.TipoDocumento, x => x.MapFrom(b => b.TipoDocumento!.Descripcion));

            CreateMap<Puesto, PuestoVm>();
            CreateMap<RefLocalidad, SeccionalLocalidadVm>();
            CreateMap<Seccional, SeccionalVm>()
                //.ForMember(a => a.SeccionalLocalidad, x => x.MapFrom(s => s.SeccionalLocalidad!.Select(x => x.RefLocalidad)))
                .ForMember(a => a.LocalidadNombre, x => x.MapFrom(s => s.RefLocalidades!.Nombre))
                .ForMember(a => a.LocalidadCodPostal, x => x.MapFrom(s => s.RefLocalidades!.CodPostal))
                .ForMember(a => a.ProvinciaId, x => x.MapFrom(s => s.RefLocalidades!.ProvinciaId))
                .ForMember(a => a.ProvinciaDescripcion, x => x.MapFrom(s => s.RefLocalidades!.Provincia!.Nombre))
                .ForMember(a => a.SeccionalEstadoDescripcion, x => x.MapFrom(s => s.SeccionalEstado!.Descripcion));
                //.ForMember(s => s.SeccionalLocalidad, opt => opt.MapFrom(x => x.SeccionalLocalidad.Select(y => y.RefLocalidad).ToList()));
            CreateMap<Seccional, CreateSeccionalVm>();
            CreateMap<Provincia, ProvinciaVm>()
                .ForMember(a => a.SeccionalDescripcionPorDefecto, x => x.MapFrom(s => s.Seccional.Descripcion));
            CreateMap<Nacionalidad, NacionalidadVm>();
            CreateMap<EstadoCivil, EstadoCivilVm>();
            CreateMap<TipoDocumento, TipoDocumentoVm>();
            CreateMap<RefLocalidad, RefLocalidadVm>()
                .ForMember(a => a.Provincia, x => x.MapFrom(b => b.Provincia!.Nombre));
            CreateMap<EstadoSolicitud, EstadoSolicitudVm>();
            CreateMap<SeccionalAutoridad, SeccionalAutoridadResponse>()
                .ForMember(a => a.SeccionalDescripcion, x => x.MapFrom(b => b.Seccional!.Descripcion));
            CreateMap<SeccionalContacto, SeccionalContactoResponse>()
                .ForMember(a => a.SeccionalDescripcion, x => x.MapFrom(b => b.Seccional!.Descripcion));
            CreateMap<SeccionalLocalidad, SeccionalLocalidadVm>()
                .ForMember(a => a.Id, x => x.MapFrom(b => b.Id))
                .ForMember(a => a.RefLocalidadId, x => x.MapFrom(b => b.RefLocalidadId))
                .ForMember(a => a.Codigo, x => x.MapFrom(b => b.RefLocalidad!.Codigo))
                .ForMember(a => a.Nombre, x => x.MapFrom(b => b.RefLocalidad!.Nombre))
                .ForMember(a => a.LitProvincia, x => x.MapFrom(b => b.RefLocalidad!.LitProvincia))
                .ForMember(a => a.CodPostal, x => x.MapFrom(b => b.RefLocalidad!.CodPostal))
                .ForMember(a => a.SeccionalDescripcion, x => x.MapFrom(b => b.Seccional!.Descripcion))
                .ForMember(a => a.SeccionalCodigo, x => x.MapFrom(b => b.Seccional!.Codigo))
                .ForMember(a => a.RefDelegacionId, x => x.MapFrom(b => b.Seccional!.RefDelegacionId));
                //.ForMember(a => a.RefDelegacionDescripcion, x => x.MapFrom(b => b.Seccional));


            CreateMap<SeccionalEstado, SeccionalEstadoResponse>();

            CreateMap<AfiliadoEstadoSolicitud, AfiliadoEstadoSolicitudVm>();

            CreateMap<Notificacion, NotificacionesResponse>();
            CreateMap<NotificacionDetalle, NotificacionesDetalleResponse>();

            // Requests
            CreateMap<CreateAfiliadoCommand, Afiliado>();
            CreateMap<UpdateAfiliadoCommand, Afiliado>();
            CreateMap<CreateSeccionalCommand, Seccional>();
            CreateMap<UpdateSeccionalCommand, Seccional>();
            CreateMap<CreateSeccionalAutoridad, SeccionalAutoridad>();
            CreateMap<CreateSeccionalLocalidad, SeccionalLocalidad>();
            CreateMap<CreateRefLocalidadCommand, RefLocalidad>().ReverseMap();
            CreateMap<UpdateRefLocalidadCommand, RefLocalidad>().ReverseMap();
            CreateMap<UpdateSeccionalAutoridadCommand, SeccionalAutoridad>();
            CreateMap<UpdateSeccionalContactoCommand, SeccionalContacto>();
            CreateMap<CreateSeccionalAutoridadCommand, SeccionalAutoridad>();
            CreateMap<CreateSeccionalContactoCommand, SeccionalContacto>();
            CreateMap<CreateSeccionalLocalidadCommand, SeccionalLocalidad>();
            CreateMap<UpdateSeccionalLocalidadCommand, SeccionalLocalidad>();
            CreateMap<UpdateRecordSeccionalLocalidadCommand, SeccionalLocalidad>();
            CreateMap<CreateSeccionalEstadoCommand, SeccionalEstado>();
            CreateMap<UpdateSeccionalEstadoCommand, SeccionalEstado>();
            CreateMap<NotificacionesCreateCommand, Notificacion>();
            CreateMap<NotificacionDetalleCreateCommand, NotificacionDetalle>();
            CreateMap<NotificacionesUpdateCommand, Notificacion>();
            CreateMap<NotificacionDetalleUpdateCommand, NotificacionDetalle>();
            CreateMap<AfiliadoFormulariosAfiliacionCreateCommand, AfiliadoFormularioAfiliacion>();
        }
    }
}
