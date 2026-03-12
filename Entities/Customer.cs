namespace Docker.Entities;

public class Customer
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Name { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public string Phone { get; private set; } = string.Empty;
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

    protected Customer() { }

    public Customer(string name, string email, string phone)
    {
        Name = name;
        Email = email;
        Phone = phone;
    }

    public void Update(string name, string email, string phone)
    {
        Name = name;
        Email = email;
        Phone = phone;
    }
}