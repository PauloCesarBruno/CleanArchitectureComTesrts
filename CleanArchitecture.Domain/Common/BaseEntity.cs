namespace CleanArchitecture.Domain.Common;

public abstract class BaseEntity
{
    public Guid Id { get; set; }
    public DateTime? DataCreated { get; set; }
    public DateTime? DataUpdated { get; set; }
    public DateTime? DataDeleted { get; set; }

}
