using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoatBookingSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BoatBookingSystem.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<ApplicationUser> Users => Set<ApplicationUser>();
        public DbSet<Boat> Boats => Set<Boat>();
        public DbSet<Trip> Trips => Set<Trip>();
        public DbSet<AdditionalService> Services => Set<AdditionalService>();
        public DbSet<Reservation> Reservations => Set<Reservation>();
        public DbSet<ReservationService> ReservationServices => Set<ReservationService>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ReservationService>()
                .HasKey(rs => new { rs.ReservationId, rs.ServiceId });

            modelBuilder.Entity<ReservationService>()
                .HasOne(rs => rs.Reservation)
                .WithMany(r => r.ReservationServices)
                .HasForeignKey(rs => rs.ReservationId)
                .OnDelete(DeleteBehavior.Cascade); 

            modelBuilder.Entity<ReservationService>()
                .HasOne(rs => rs.Service)
                .WithMany(s => s.ReservationServices)
                .HasForeignKey(rs => rs.ServiceId)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<AdditionalService>()
                .Property(x => x.Price)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Boat>()
                .Property(x => x.PricePerHour)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Reservation>()
                .Property(x => x.TotalPrice)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Trip>()
                .Property(x => x.PricePerPerson)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Boat>()
                .HasOne(b => b.Owner)
                .WithMany()
                .HasForeignKey(b => b.OwnerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Trip>()
                .HasOne(t => t.Owner)
                .WithMany()
                .HasForeignKey(t => t.OwnerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Trip>()
                .HasOne(t => t.Boat)
                .WithMany(b => b.Trips)
                .HasForeignKey(t => t.BoatId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
