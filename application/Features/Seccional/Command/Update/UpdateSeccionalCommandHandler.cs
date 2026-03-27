using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Models.APIComunes;
using CleanArchitecture.Common.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Features.Seccional.Command.Update
{
    public class UpdateSeccionalCommandHandler : IRequestHandler<UpdateSeccionalCommand, int>
    {
        private readonly ILogger<UpdateSeccionalCommandHandler> logger;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public UpdateSeccionalCommandHandler(ILogger<UpdateSeccionalCommandHandler> logger, IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.logger = logger;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }
        public async Task<int> Handle(UpdateSeccionalCommand request, CancellationToken cancellationToken)
        {
            var entidad = await unitOfWork.Repository<Domain.Seccional>().GetByIdAsync(request.Id);
            if (entidad == null)
            {
                logger.LogError("No existe Seccional");
                throw new BadRequestException($"No existe Seccional con Id {request.Id}");
            }

            if (request.SeccionalLocalidad != null)
            {
                foreach (var item in request.SeccionalLocalidad)
                {
                    var refLocalidad = await unitOfWork.Repository<Domain.RefLocalidad>().GetByIdAsync(item.RefLocalidadId);
                    if (refLocalidad == null)
                    {
                        logger.LogError("No existe RefLocalidad");
                        throw new BadRequestException($"No existe RefLocalidad con Id {item.RefLocalidadId}");
                    }                    
                }                
            }
            

            mapper.Map(request, entidad, typeof(UpdateSeccionalCommand), typeof(Domain.Seccional));

            try
            {
                await unitOfWork.Repository<Domain.Seccional>().UpdateAsync(entidad);

                if (request.Documentacion != null)
                {
                    foreach (var item in request.Documentacion!)
                    {
                        var reg = await unitOfWork.RefRepository.GetDocumentacionEntidadById("A", item.Id);
                        if (reg == null)
                        {
                            await unitOfWork.RefRepository.AgregarDocumentacionEntidad(item, "A", entidad.Id);
                        }
                        else
                        {
                            if (!reg.Equals(item))
                            {
                                await unitOfWork.RefRepository.BorrarDocumentacionEntidad(item.Id);
                                await unitOfWork.RefRepository.AgregarDocumentacionEntidad(item, "A", entidad.Id);
                            }                            
                        }
                    }
                }                             

                return await unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                logger.LogError("No se actualizó el registro de Seccional");
                throw new Exception("No se pudo insertar Seccional " + ex.Message);
            }
        }
    }
}
