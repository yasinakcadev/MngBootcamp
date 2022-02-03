using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Fuel : Entity
{
    public Fuel()
    {
        Models = new HashSet<Model>();
    }
    public Fuel(int id, string name) : this()
    {
        Id = id;
        Name = name;
    }
    public string Name { get; set; }
    public ICollection<Model> Models { get; set; }
}