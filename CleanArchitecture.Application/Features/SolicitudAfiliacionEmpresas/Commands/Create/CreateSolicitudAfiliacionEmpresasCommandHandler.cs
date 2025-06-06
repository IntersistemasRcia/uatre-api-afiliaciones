using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Features.Seccional.Command.Create;
using CleanArchitecture.Application.Features.SeccionalAutoridad.Command.CreateSeccionalAutoridad;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Features.SolicitudAfiliacionEmpresas.Commands.Create
{
    public class CreateSolicitudAfiliacionEmpresasCommandHandler : IRequestHandler<CreateSolicitudAfiliacionEmpresasCommand, CreateSolicitudAfiliacionEmpresasVm>
    {
        private readonly ILogger<CreateSolicitudAfiliacionEmpresasCommand> logger;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public CreateSolicitudAfiliacionEmpresasCommandHandler(ILogger<CreateSolicitudAfiliacionEmpresasCommand> logger, IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.logger = logger;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }
        public async Task<CreateSolicitudAfiliacionEmpresasVm> Handle(CreateSolicitudAfiliacionEmpresasCommand request, CancellationToken cancellationToken)
        {
            

            try
            {
                var entidad = mapper.Map<Domain.SolicitudAfiliacionEmpresas>(request);
                await unitOfWork.Repository<Domain.SolicitudAfiliacionEmpresas>().AddAsync(entidad);

                /*if (request.Documentacion?.Count > 0)
                {
                    await unitOfWork.RefRepository.AgregarDocumentacionEntidad(request.Documentacion, "S", entidad.Id);
                }*/

                var result = await unitOfWork.CommitAsync();

                return mapper.Map<CreateSolicitudAfiliacionEmpresasVm>(entidad);
            }
            catch (Exception ex)
            {
                logger.LogError($"No se insertó el registro de SolicitudAfiliacionEmpresas {ex.Message}");
                throw new Exception($"No se pudo insertar SolicitudAfiliacionEmpresas. {ex.Message}");
            }
        }
    }
}

