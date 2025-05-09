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
            var entityToUpdate = await unitOfWork.Repository<Domain.AccesoOsprera>().GetByIdAsync(request.Id);

            entityToUpdate = (Domain.AccesoOsprera)mapper.Map(request, entityToUpdate, typeof(UpdateAccesoOspreraCommand), typeof(Domain.AccesoOsprera));

            using (var transaction = await unitOfWork.BeginTransactionAsync())
            {
                try
                {
                    if (request.Documentacion?.Count > 0)
                    {
                        await unitOfWork.RefRepository.BorrarDocumentacionEntidad("O", request.Id);
                        await unitOfWork.RefRepository.AgregarDocumentacionEntidad(request.Documentacion, "O", request.Id);
                        //foreach (var item in request.Documentacion!)
                        //{
                        //    item.Id = 0;
                        //    await unitOfWork.RefRepository.AddAsync(item);
                        //}
                    }

                    await transaction.CommitAsync();

                    return await unitOfWork.CommitAsync();
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();

                    logger.LogError("No se actualizó el registro de Gestion Osprera");
                    throw new Exception("No se pudo actualizar la Gestion Osprera. " + ex.Message);
                }
            }
        }
    }
}
