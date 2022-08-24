using System.ComponentModel.DataAnnotations;

namespace WebApi.HomeTask.Dal.Infrastructure;

public abstract class NameableEntity : BaseIdEntity<int>
{
    [StringLength(512)] public virtual string Name { get; set; }
}