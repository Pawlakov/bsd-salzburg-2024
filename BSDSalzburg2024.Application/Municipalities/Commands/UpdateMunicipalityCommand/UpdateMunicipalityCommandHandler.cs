namespace BSDSalzburg2024.Application.Municipalities.Commands.UpdateMunicipalityCommand;

using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

public class UpdateMunicipalityCommandHandler
    : IRequestHandler<UpdateMunicipalityCommand>
{
    public Task Handle(UpdateMunicipalityCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}