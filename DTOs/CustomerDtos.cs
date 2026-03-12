namespace Docker.DTOs;

public record CreateCustomerRequest(
    string Name,
    string Email,
    string Phone
);

public record UpdateCustomerRequest(
    string Name,
    string Email,
    string Phone
);

public record CustomerResponse(
    Guid Id,
    string Name,
    string Email,
    string Phone,
    DateTime CreatedAt
);