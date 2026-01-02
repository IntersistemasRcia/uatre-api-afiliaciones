using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Common.Exceptions;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Features.SeccionalContacto.Command.ReactivarSeccionalContacto;

public class ReactivarSeccionalContactoCommandHandler : IRequestHandler<ReactivarSeccionalContactoCommand, int>
{
    private readonly ILogger<ReactivarSeccionalContactoCommandHandler> logger;
    private readonly IMapper mapper;
    private readonly IUnitOfWork unitOfWork;

    public ReactivarSeccionalContactoCommandHandler(ILogger<ReactivarSeccionalContactoCommandHandler> logger, IMapper mapper, IUnitOfWork unitOfWork)
    {
        this.logger = logger;
        this.mapper = mapper;
        this.unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(ReactivarSeccionalContactoCommand request, CancellationToken cancellationToken)
    {
        var entidad = await unitOfWork.Repository<Domain.SeccionalContacto>().GetByIdAsync(request.Id);
        if (entidad == null || entidad.DeletedDate == null)
        {
            throw new NotFoundException(nameof(Seccional), request.Id);
        }

        var patchModel = new JsonPatchDocument();

        try
        {
            patchModel.Replace(nameof(Domain.SeccionalContacto.DeletedDate), null);
            patchModel.Replace(nameof(Domain.SeccionalContacto.DeletedBy), null);
            patchModel.Replace(nameof(Domain.SeccionalContacto.DeletedObs), null);

            unitOfWork.Repository<Domain.SeccionalContacto>().ReactivarAsync(entidad, patchModel);
            return await unitOfWork.CommitAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }
}
