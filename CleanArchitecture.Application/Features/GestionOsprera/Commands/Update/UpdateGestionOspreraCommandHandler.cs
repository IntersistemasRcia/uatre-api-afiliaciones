using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Features.GestionOsprera.Commands.Update
{
    public class UpdateGestionOspreraCommandHandler : IRequestHandler<UpdateGestionOspreraCommand, int>
    {
        private readonly ILogger<UpdateGestionOspreraCommandHandler> logger;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public UpdateGestionOspreraCommandHandler(ILogger<UpdateGestionOspreraCommandHandler> logger, IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.logger = logger;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }
        public async Task<int> Handle(UpdateGestionOspreraCommand request, CancellationToken cancellationToken)
        {
            var entityToUpdate = await unitOfWork.Repository<Domain.GestionOsprera>().GetByIdAsync(request.Id);

            entityToUpdate = (Domain.GestionOsprera)mapper.Map(request, entityToUpdate, typeof(UpdateGestionOspreraCommand), typeof(Domain.GestionOsprera));

            using (var transaction = await unitOfWork.BeginTransactionAsync())
            {
                try
                {
                    //if (request.Documentacion?.Count > 0)
                    //{
                    //    await unitOfWork.RefRepository.BorrarDocumentacionEntidad("O", request.Id);
                    //    await unitOfWork.RefRepository.AgregarDocumentacionEntidad(request.Documentacion, "O", request.Id);
                    //    //foreach (var item in request.Documentacion!)
                    //    //{
                    //    //    item.Id = 0;
                    //    //    await unitOfWork.RefRepository.AddAsync(item);
                    //    //}
                    //}                    

                    var ret = await unitOfWork.CommitAsync();

                    await transaction.CommitAsync();

                    return ret;
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
