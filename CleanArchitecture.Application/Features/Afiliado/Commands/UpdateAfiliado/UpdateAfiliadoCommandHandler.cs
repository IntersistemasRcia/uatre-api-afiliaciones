using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Models.APIComunes;
using CleanArchitecture.Application.Specification.Implements;
using CleanArchitecture.Common.Exceptions;
using CleanArchitecture.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Features.Afiliado.Commands.UpdateAfiliado
{
    public class UpdateAfiliadoCommandHandler : IRequestHandler<UpdateAfiliadoCommand, int>
    {
        private readonly ILogger<UpdateAfiliadoCommandHandler> logger;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public UpdateAfiliadoCommandHandler(ILogger<UpdateAfiliadoCommandHandler> logger, IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.logger = logger;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }
        public async Task<int> Handle(UpdateAfiliadoCommand request, CancellationToken cancellationToken)
        {

            var entityToUpdate = await unitOfWork.Repository<Domain.Afiliado>().GetByIdAsync(request.Id);

            entityToUpdate = (Domain.Afiliado)mapper.Map(request, entityToUpdate, typeof(UpdateAfiliadoCommand), typeof(Domain.Afiliado));

            try
            {
                await unitOfWork.AfiliadoRepository.ModificarAfiliado(entityToUpdate, request.Empresa!);

                if (request.Documentacion?.Count > 0)
                {
                    await unitOfWork.RefRepository.BorrarDocumentacionEntidad("A", request.Id);
                    foreach (var item in request.Documentacion!)
                    {
                        item.Id = 0;
                        await unitOfWork.RefRepository.AddAsync(item);
                    }
                }

                var t1 = unitOfWork.CommitAsync();
                var t2 = unitOfWork.CommitAsyncUatreRefContext();

                await Task.WhenAll(t1, t2);

                return t1.Result + t2.Result;
            }
            catch (Exception ex)
            {
                logger.LogError("No se actualizó el registro de Afiliado");
                throw new Exception("No se pudo actualizar Afiliado. " + ex.Message);
            }
        }
    }
}
