namespace Calcis.Shared.Events.Employee
{
    public record CreatedUserCommand(Guid id, string firstName, string lastName, string email, long createdTimestamp);
}
