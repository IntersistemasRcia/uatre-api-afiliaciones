using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Features.RefLocalidad.Command.Update;
using CleanArchitecture.Common.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Features.SeccionalEstado.Commands.UpdateSeccionalEstado;

public class UpdateSeccionalEstadoCommandHandler : IRequestHandler<UpdateSeccionalEstadoCommand, int>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public UpdateSeccionalEstadoCommandHandler(IUnitOfWork unitOfWork, 
        IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<int> Handle(UpdateSeccionalEstadoCommand request, CancellationToken cancellationToken)
    {
        var entidad = await unitOfWork.Repository<Domain.SeccionalEstado>().GetByIdAsync(request.Id);
        if (entidad == null)
        {
            throw new BadRequestException($"No existe {nameof(Domain.SeccionalEstado)} {request.Id}");
        }

        mapper.Map(request, entidad, typeof(UpdateSeccionalEstadoCommand), typeof(Domain.SeccionalEstado));

        try
        {
            await unitOfWork.Repository<Domain.SeccionalEstado>().UpdateAsync(entidad);

            return await unitOfWork.CommitAsync();
        }
        catch (Exception)
        {
            throw new Exception($"No se pudo insertar {nameof(Domain.SeccionalEstado)}");
        }
    }
}
