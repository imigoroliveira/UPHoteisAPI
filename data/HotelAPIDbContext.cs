using UPHoteisAPI.Models;
using Microsoft.EntityFrameworkCore;

    namespace UPHoteisAPI.Data;

    public class HotelAPIDbContext : DbContext
    {
        public HotelAPIDbContext(DbContextOptions<HotelAPIDbContext> options) : base(options){

        }

        public DbSet<Reservation> Reservations{get; set;}
    }