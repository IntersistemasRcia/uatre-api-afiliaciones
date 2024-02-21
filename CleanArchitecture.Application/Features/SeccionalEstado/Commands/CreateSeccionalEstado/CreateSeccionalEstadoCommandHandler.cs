using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Features.SeccionalEstado.Commands.CreateSeccionalEstado;

public class CreateSeccionalEstadoCommandHandler : IRequestHandler<CreateSeccionalEstadoCommand, int>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public CreateSeccionalEstadoCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<int> Handle(CreateSeccionalEstadoCommand request, CancellationToken cancellationToken)
    {
        var entidad = mapper.Map<Domain.SeccionalEstado>(request);

        try
        {
            await unitOfWork.Repository<Domain.SeccionalEstado>().AddAsync(entidad);
            var result = await unitOfWork.CommitAsync();
        }
        catch (Exception)
        {
            //logger.LogError("No se insertó el registro de SeccionalContacto");
            throw new Exception($"No se pudo insertar {nameof(Domain.SeccionalEstado)}");
        }


        return entidad.Id;
    }
}
