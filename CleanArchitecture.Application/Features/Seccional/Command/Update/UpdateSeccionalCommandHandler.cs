using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Models.APIComunes;
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
                throw new Exception("No existe Seccional");
            }

            mapper.Map(request, entidad, typeof(UpdateSeccionalCommand), typeof(Domain.Seccional));

            try
            {
                await unitOfWork.Repository<Domain.Seccional>().UpdateAsync(entidad);

                if (request.Documentacion != null)
                {
                    foreach (var item in request.Documentacion!)
                    {
                        var reg = await unitOfWork.RefRepository.GetById<DocumentacionEntidad>(item.Id);
                        if (reg != null)
                        {
                            await unitOfWork.RefRepository.AddAsync(item);
                        }
                        else
                        {
                            await unitOfWork.RefRepository.UpdateAsync(item);
                        }
                    }
                }                             

                return await unitOfWork.CommitAsync();
            }
            catch (Exception)
            {
                logger.LogError("No se actualizó el registro de Seccional");
                throw new Exception("No se pudo insertar Seccional");
            }
        }
    }
}
