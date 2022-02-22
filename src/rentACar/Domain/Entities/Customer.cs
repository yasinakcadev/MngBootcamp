using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Domain.Entities;

public class Customer : Entity
{
    public Customer()
    {
      
    }
    public Customer(int id,int userId) : this()
    {
        Id = id;
        UserId = userId;
    }
    public int UserId { get; set; }
    public virtual User User { get; set; }
}