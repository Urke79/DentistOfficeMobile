using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Extensions.Configuration;

namespace MobileApp.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
            // TODO Check if this is the correct place for calling this method
            Database.EnsureCreated();
        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Intervention> Interventions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=20.52.156.112;Initial Catalog=Dentists;User ID=user;pwd=test12345",
                options => options.EnableRetryOnFailure());           
        }
    }

    [Table("Client")]
    public class Client
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public string Note { get; set; }
        public ICollection<Intervention> Interventions { get; set; }
    }

    [Table("Intervention")]
    public class Intervention
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string InterventionDescription { get; set; }
        public string Note { get; set; }
        public int Price { get; set; }
        public Client Client { get; set; }
        public int ClientId { get; set; }
    }
}
