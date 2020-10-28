using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Text;
using static Java.Util.Jar.Attributes;

namespace MobileApp.Data
{
    public class AppDbContext : DbContext
    {

        public DbSet<Client> Clients { get; set; }
        public DbSet<Intervention> Interventions { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={Consts.dbPath}");
        }
    }

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
