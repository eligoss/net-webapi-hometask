using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.HomeTask.Dal.Infrastructure;

public abstract class BaseIdEntity<T>
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public T Id { get; set; }
}