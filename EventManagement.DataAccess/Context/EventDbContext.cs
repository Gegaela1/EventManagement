using EventManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventManagement.DataAccess.Context;

public class EventDbContext : DbContext
{
    public EventDbContext(DbContextOptions<EventDbContext> options)
        : base(options)
    {
    }
    //Crea las tablas de las entidades
    public DbSet<Event> Events => Set<Event>();
    public DbSet<Venue> Venues => Set<Venue>();
    public DbSet<Organizer> Organizers => Set<Organizer>();
    public DbSet<Attendee> Attendees => Set<Attendee>();
    public DbSet<Ticket> Tickets => Set<Ticket>();


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(150);

            entity.Property(e => e.Location)
                .HasMaxLength(200);

            // RELACIÓN: EVENT → VENUE
            entity.HasOne(e => e.Venue)             // Un evento tiene un luegar
                .WithMany(v => v.Events)           // Venue tiene muchos Events
                .HasForeignKey(e => e.VenueId);    // FK

            // RELACIÓN: EVENT → ORGANIZER
            entity.HasOne(e => e.Organizer)   //Un organizador maneja eventos
                .WithMany(o => o.Events)
                .HasForeignKey(e => e.OrganizerId);
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(t => t.Id);

            entity.Property(t => t.Price)
                .HasColumnType("decimal(18,2)");

            // RELACIÓN: Ticket → Event
            entity.HasOne(t => t.Event)
                .WithMany() // un Evento tiene muchos tickets
                .HasForeignKey(t => t.EventId);

            // RELACIÓN: Ticket → Attendee
            entity.HasOne(t => t.Attendee)
                .WithMany(a => a.Tickets)
                .HasForeignKey(t => t.AttendeeId);
        });

    }
}