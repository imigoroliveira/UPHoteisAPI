using UPHoteisAPI.Models;
using Microsoft.EntityFrameworkCore;

    namespace UPHoteisAPI.Data;

    public class HotelAPIDbContext : DbContext
    {
        public HotelAPIDbContext(DbContextOptions<HotelAPIDbContext> options) : base(options) { }

        public DbSet<Reserva> reservas { get; set;}

        public DbSet<Cliente> clientes { get; set; }

        public DbSet<Quarto> quartos { get; set; }
        
        public DbSet<Hotel> hoteis { get; set; }

        public DbSet<Avaliacao> avaliacoes { get; set; }

        public DbSet<Servico> servicos { get; set; }

}