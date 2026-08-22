using DataAccess.EntityConfiguration;
 using Domain.Models;
 using Microsoft.EntityFrameworkCore;
 
 namespace DataAccess.Data;
 
 public class AppDbContext : DbContext
 {
     public AppDbContext(DbContextOptions<AppDbContext> options)
         : base(options)
     {
     }
 

     public DbSet<User> Users { get; set; }
     public DbSet<Room> Rooms { get; set; }
     public DbSet<Tap> Taps { get; set; }
 
     protected override void OnModelCreating(ModelBuilder modelBuilder)
     {
         base.OnModelCreating(modelBuilder);

         modelBuilder.ApplyConfiguration(new RoomConfiguration());
         modelBuilder.ApplyConfiguration(new UserConfiguration());
         modelBuilder.ApplyConfiguration(new TapConfiguration());
     }
 }