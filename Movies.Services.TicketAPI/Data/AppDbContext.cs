using Microsoft.EntityFrameworkCore;
using Movies.Services.TicketAPI.Models;


namespace Movies.Services.TicketAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        { 
        }
        public DbSet<Ticket> Tickets { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Ticket>().HasData(new Ticket
            {
                TicketId = 1,
                TicketCode = "123A",
                TicketPrice = 10
            });
            modelBuilder.Entity<Ticket>().HasData(new Ticket
            {
                TicketId = 2,
                TicketCode = "123B",
                TicketPrice = 15
            });
            modelBuilder.Entity<Ticket>().HasData(new Ticket
            {
                TicketId = 3,
                TicketCode = "123C",
                TicketPrice = 17
            });
        }
    }
}
