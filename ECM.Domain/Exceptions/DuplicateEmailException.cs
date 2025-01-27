namespace ECM.Domain.Exceptions;

public class DuplicateEmailException(string email, Exception innerException)
    : Exception($"A user with the email '{email}' already exists.", innerException)
{
    public string Email { get; } = email;
}