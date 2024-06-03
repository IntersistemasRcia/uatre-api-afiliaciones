using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Models.APIComunes;
using CleanArchitecture.Domain;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Features.Afiliado.Commands.CreateAfiliado
{
    public class CreateAfiliadoCommandHandler : IRequestHandler<CreateAfiliadoCommand, int>
    {
        private readonly ILogger<CreateAfiliadoCommandHandler> logger;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public CreateAfiliadoCommandHandler(ILogger<CreateAfiliadoCommandHandler> logger, IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.logger = logger;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }
        public async Task<int> Handle(CreateAfiliadoCommand request, CancellationToken cancellationToken)
        {
            var entidad = mapper.Map<Domain.Afiliado>(request);

            using (var transaction = await unitOfWork.BeginTransactionAsync())
            {
                try
                {
                    //await unitOfWork.AfiliadoRepository.CrearAfiliado(entidad, request.Empresa!);
                    entidad.EmpresaId = await unitOfWork.AfiliadoRepository.BuscarEmpresa(request.Empresa);
                    if (entidad.EmpresaId == 0)
                    {
                        throw new Exception("Error buscando/creando Empresa");
                    }

                    if (entidad.EstadoSolicitudId == 2)
                    {
                        entidad.NroAfiliado = await unitOfWork.AfiliadoRepository.GetNroAfiliado();
                    }
                    await unitOfWork.Repository<Domain.Afiliado>().AddAsync(entidad);
                    var result = await unitOfWork.CommitAsync();

                    if (request.Documentacion?.Count > 0)
                    {
                        await unitOfWork.RefRepository.AgregarDocumentacionEntidad(request.Documentacion, "A", entidad.Id);
                    }

                    await transaction.CommitAsync();

                    return entidad.Id;
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();

                    logger.LogError("No se insertó el registro de Afiliado");
                    throw new Exception("No se pudo insertar Afiliado. " + ex.InnerException);
                }
            }
        }
    }
}
