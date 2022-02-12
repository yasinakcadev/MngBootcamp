using Core.Persistence.Repositories;

namespace Domain.Entities;

public class AdditionalService : Entity
{
    public string Name { get; set; }
    public double DailyPrice { get; set; }
    public virtual ICollection<Rent> Rents { get; set; }
}