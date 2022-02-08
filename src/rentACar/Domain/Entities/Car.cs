using Core.Persistence.Repositories;
using Domain.Enums;

namespace Domain.Entities;

public class Car : Entity
{
    public Car()
    {

    }

    public Car(int id, int colorId, int modelId, string plate, short modelYear,short minFindexScore, CarState carState) : this()
    {
        Id = id;
        ColorId = colorId;
        ModelId = modelId;
        Plate = plate;
        CityId = cityId;
        ModelYear = modelYear;
        CarState = carState;
        MinFindexScore = minFindexScore;
    }
    public int ColorId { get; set; }
    public CarState CarState { get; set; }
    public virtual Color Color { get; set; }
    public int ModelId { get; set; }
    public short MinFindexScore { get; set; }
    public virtual Model Model { get; set; }
    public int CityId { get; set; }
    public virtual City City { get; set; }
    public short ModelYear { get; set; }
    public string Plate { get; set; }
}