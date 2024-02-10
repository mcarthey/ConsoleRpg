using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleRpg.Entities;

// In this code, the InverseProperty attribute on the Location property tells Entity Framework
// that the Exits property in the Location class is the inverse of this property.
// The ForeignKey attribute on the DestinationLocation property tells Entity Framework that
// DestinationLocationId is the foreign key for this property.
public class Exit
{
    [ForeignKey("DestinationLocationId")] public virtual Location DestinationLocation { get; set; } // New navigation property

    public int DestinationLocationId { get; set; } // New foreign key property
    public string Direction { get; set; }
    public int Id { get; set; }

    [InverseProperty("Exits")] public virtual Location Location { get; set; } // Navigation property

    public int LocationId { get; set; } // Foreign key property
}
