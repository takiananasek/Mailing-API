using ClientApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ClientApi.Data
{
    public class ApplicationDbContext :DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Charging> Chargings { get; set; }
        public DbSet<UserClient> UserClient { get; set; }
        public DbSet<ChargingVariant> ChargingVariants { get; set; }
        public DbSet<ClientRequest> ClientRequests { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Charging>()
                .HasOne<ChargingVariant>(ch => ch.ChargingVariant)
                .WithMany(chv => chv.Chargings)
                .HasForeignKey(ch => ch.ChargingVariantId)
                .IsRequired();

            modelBuilder.Entity<Charging>()
                .HasOne<Client>(ch => ch.Client)
                .WithMany(c => c.Chargings)
                .HasForeignKey(c => c.ClientId)
                .IsRequired();

            modelBuilder.Entity<ClientRequest>()
                .HasOne<Client>(cr => cr.Client)
                .WithMany(c => c.ClientRequests)
                .HasForeignKey(c => c.ClientId)
                .IsRequired();

            //modelBuilder.Entity<User>()
            //    .HasOne<Client>(u => u.Client)
            //    .WithMany(c => c.Users)
            //    .HasForeignKey(u => u.ClientId)
            //    .IsRequired();

            modelBuilder.Entity<UserClient>().HasKey(uc => new { uc.UserId, uc.ClientId });
            modelBuilder.Entity<UserClient>()
                .HasOne<Client>(uc => uc.Client)
                .WithMany(c =>  c.UserClient)
                .HasForeignKey(uc => uc.ClientId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserClient>()
                .HasOne<User>(uc => uc.User)
                .WithMany(u => u.UserClient)
                .HasForeignKey(uc => uc.UserId).OnDelete(DeleteBehavior.Restrict);


        }
    }
}
