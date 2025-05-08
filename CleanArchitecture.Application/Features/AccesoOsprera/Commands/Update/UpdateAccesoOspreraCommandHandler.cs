using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Models.APIComunes;
using CleanArchitecture.Common.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Features.AccesoOsprera.Commands.Update
{
    public class UpdateAccesoOspreraCommandHandler : IRequestHandler<UpdateAccesoOspreraCommand, int>
    {
        private readonly ILogger<UpdateAccesoOspreraCommandHandler> logger;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public UpdateAccesoOspreraCommandHandler(ILogger<UpdateAccesoOspreraCommandHandler> logger, IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.logger = logger;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }
        public async Task<int> Handle(UpdateAccesoOspreraCommand request, CancellationToken cancellationToken)
        {
            var entidad = await unitOfWork.Repository<Domain.AccesoOsprera>().GetByIdAsync(request.Id);
            if (entidad == null)
            {
                logger.LogError("No existe Gestión");
                throw new BadRequestException($"No existe la Gestión con Id {request.Id}");
            }


            mapper.Map(request, entidad, typeof(UpdateAccesoOspreraCommand), typeof(Domain.AccesoOsprera));

            try
            {
                await unitOfWork.Repository<Domain.AccesoOsprera>().UpdateAsync(entidad);
                return await unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                logger.LogError("No se actualizó la Gestion Osprera");
                throw new Exception("No se pudo insertar La Gestion " + ex.Message);
            }
        }
    }
}
