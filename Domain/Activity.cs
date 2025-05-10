using System;
using System.ComponentModel.DataAnnotations;

namespace Domain;

public class Activity
{
    public string Id { get; set; } = Guid.NewGuid().ToString();

    [MaxLength(100)]
    public required string Title { get; set; }

    public DateTime Date { get; set; } = new DateTime(1753, 1, 1);

    [MaxLength(2000)]
    public required string Description { get; set; }

    [MaxLength(100)]
    public required string Category { get; set; }
    public bool IsCancelled { get; set; }

    [MaxLength(200)]
    public required string City { get; set; }

    [MaxLength(1500)]
    public required string Venue { get; set; }

    public double Latitude { get; set; }
    public double Longitude { get; set; }

}
