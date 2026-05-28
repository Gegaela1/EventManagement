using EventManagement.DataAccess.Context;
using EventManagement.Domain.Entities;

public static class DataSeeder
{
    public static void Seed(EventDbContext context)
    {
        if (!context.Venues.Any())
        {
            context.Venues.AddRange(
                new Venue { Name = "Estadio", Address = "Centro" },
                new Venue { Name = "Teatro", Address = "Norte" }
            );
        }

        if (!context.Organizers.Any())
        {
            context.Organizers.AddRange(
                new Organizer { Name = "Empresa Eventos", Email = "eventos@mail.com" },
                new Organizer { Name = "Producciones XYZ", Email = "xyz@mail.com" }
            );
        }

        context.SaveChanges();
    }
}

