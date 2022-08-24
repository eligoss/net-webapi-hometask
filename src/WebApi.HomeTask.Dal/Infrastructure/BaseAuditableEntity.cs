namespace WebApi.HomeTask.Dal.Infrastructure;

public abstract class BaseAuditableEntity : BaseIdEntity<int>
{
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public DateTime? UpdatedAt { get; set; }
}