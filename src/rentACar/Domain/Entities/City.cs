using Core.Persistence.Repositories;

namespace Domain.Entities;

public class City : Entity
{
    public City()
    {
        Cars = new HashSet<Car>();
    }

    public City(int id, string name) : this()
    {
        Id = id;
        Name = name;
    }

    public string Name { get; set; }

    public ICollection<Car> Cars { get; set; }
}