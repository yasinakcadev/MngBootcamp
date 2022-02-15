using Core.Persistence.Repositories;

namespace Domain.Entities;

public class AdditionalService : Entity
{
    public AdditionalService()
    {

    }

    public AdditionalService(int id,string name, double dailyPrice, ICollection<Rent> rents):this()
    {
        Id = id;
        Name = name;
        DailyPrice = dailyPrice;
        Rents = rents;
    }

    public string Name { get; set; }
    public double DailyPrice { get; set; }
    public virtual ICollection<Rent> Rents { get; set; }

}