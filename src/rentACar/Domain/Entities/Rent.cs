using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Rent : Entity
{
    public Rent()
    {
    }

    public Rent(int carId, int customerId, DateTime endDate, int? givingCityId, int? invoiceId, DateTime startDate,
        int? takingCityId, int startIndicatorValueAsKilometer)
    {
        CarId = carId;
        CustomerId = customerId;
        EndDate = endDate;
        GivingCityId = givingCityId;
        InvoiceId = invoiceId;
        StartDate = startDate;
        StartIndicatorValueAsKilometer = startIndicatorValueAsKilometer;
        TakingCityId = takingCityId;
    }

    public int CustomerId { get; set; }
    public int InvoiceId { get; set; }
    public int StartIndicatorValueAsKilometer { get; set; }
    public int? EndIndicatorValueAsKilometer { get; set; }
    public int CarId { get; set; }
    public int? GivingCityId { get; set; }
    public int? TakingCityId { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public virtual Car Car { get; set; }
    public virtual City? GivingCity { get; set; }
    public virtual City? TakingCity { get; set; }
    public virtual Invoice Invoice { get; set; }
}