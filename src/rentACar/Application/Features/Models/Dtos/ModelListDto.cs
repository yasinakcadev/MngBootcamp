namespace Application.Features.Models.Dtos;

public class ModelListDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double DailyPrice { get; set; }
    public string ImageUrl { get; set; }
    public int TransmissionId { get; set; }
    public int FuelId { get; set; }
    public int BrandId { get; set; }
}