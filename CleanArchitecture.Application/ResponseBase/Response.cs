namespace CleanArchitecture.Application.ResponseBase;

public record Response
{
    public Guid Id { get; set; }
    public string? Email { get; set; }
    public string? Nome { get; set; }
}
