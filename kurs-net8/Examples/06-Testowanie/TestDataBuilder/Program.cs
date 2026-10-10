using Xunit;

public sealed class User
{
    public Guid Id { get; init; }
    public string FirstName { get; init; } = "";
    public string LastName { get; init; } = "";
    public string Email { get; init; } = "";
    public bool IsActive { get; init; }
}

// TestDataBuilder
public sealed class UserBuilder
{
    private Guid _id = Guid.NewGuid();
    private string _firstName = "Jan";
    private string _lastName = "Kowalski";
    private string _email = "jan.kowalski@example.com";
    private bool _isActive = true;

    public UserBuilder WithId(Guid id) { _id = id; return this; }
    public UserBuilder WithFirstName(string firstName) { _firstName = firstName; return this; }
    public UserBuilder WithLastName(string lastName) { _lastName = lastName; return this; }
    public UserBuilder WithEmail(string email) { _email = email; return this; }
    public UserBuilder Inactive() { _isActive = false; return this; }

    public User Build() => new()
    {
        Id = _id,
        FirstName = _firstName,
        LastName = _lastName,
        Email = _email,
        IsActive = _isActive
    };
}