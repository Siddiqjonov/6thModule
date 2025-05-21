namespace CarSystem.Dal.Entities;

public class Car
{
    public long Id { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public string Color { get; set; }
    public bool IsAvailable { get; set; }
    public long UserId { get; set; }
    public User User { get; set; }
}
