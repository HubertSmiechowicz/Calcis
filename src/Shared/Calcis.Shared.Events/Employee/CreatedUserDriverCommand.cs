using MediatR;

namespace Calcis.Shared.Events.Employee
{
    public record CreatedUserDriverCommand(Guid id, string firstName, string lastName, string email) : IRequest;
}
