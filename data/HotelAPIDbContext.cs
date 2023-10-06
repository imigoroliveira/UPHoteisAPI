using UPHoteisAPI.Models;
using Microsoft.EntityFrameworkCore;

    namespace UPHoteisAPI.Data;

    public class HotelAPIDbContext : DbContext
    {
        public HotelAPIDbContext(DbContextOptions<HotelAPIDbContext> options) : base(options) { }

        public DbSet<Reserva> Reservas { get; set;}
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Quarto> Quartos { get; set; }
        public DbSet<Hotel> Hoteis { get; set; }
        public DbSet<Avaliacao> Avaliacoes { get; set; }
        public DbSet<ServicoQuarto> Servicos { get; set; }
        
    }