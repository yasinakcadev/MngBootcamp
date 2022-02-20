using Core.Persistence.Repositories;
using Core.Security.Entities;
using Domain.Entities;


namespace Domain.FindexScore;

public class FindexScore : Entity
{
    public FindexScore()
    {
        
    }
    public FindexScore(int id, int userId, short score) : this()
    {
        Id = id;
        UserId = userId;
        Score = score;
    }

    public int UserId { get; set; }
    public short Score { get; set; }
    public virtual User User { get; set; }
}