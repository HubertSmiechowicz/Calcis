using MediatR;

namespace Calcis.Shared.Events.Employee
{
    public record CreatedUserMechanicCommand(Guid id, string firstName, string lastName, string email) : IRequest;
}
