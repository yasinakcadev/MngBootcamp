using Core.Persistence.Repositories;
using Domain.Entities;
using Domain.Entities.Abstarct;

namespace Domain.FindexScore;

public class FindexScore : Entity
{
    public FindexScore()
    {
        
    }
    public FindexScore(int id, int customerId, short score) : this()
    {
        Id = id;
        CustomerId = customerId;
        Score = score;
    }

    public int CustomerId { get; set; }
    public short Score { get; set; }
    public virtual Customer Customer { get; set; }
}