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

            try
            {
                await unitOfWork.AfiliadoRepository.CrearAfiliado(entidad, request.Empresa!);
                var result = await unitOfWork.CommitAsync();

                if (request.Documentacion?.Count > 0)
                {
                    unitOfWork.RefRepository.AgregarDocumentacionEntidad(request.Documentacion, "A", entidad.Id);
                }

                return entidad.Id;
            }
            catch (Exception ex)
            {
                logger.LogError("No se insertó el registro de Afiliado");
                throw new Exception("No se pudo insertar Afiliado. " + ex.InnerException);
            }            
        }
    }
}
