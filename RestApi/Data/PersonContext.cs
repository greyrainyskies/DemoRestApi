using Microsoft.EntityFrameworkCore;
using RestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Data
{
    public class PersonContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }

        public PersonContext(DbContextOptions<PersonContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .HasKey(t => t.Id);

            modelBuilder.Entity<Person>(entity =>
            {
                entity.Property(e => e.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                .HasColumnName("Name")
                .HasMaxLength(70)
                .IsRequired();

                entity.Property(e => e.Gender)
                .HasColumnName("Gender");

                entity.Property(e => e.Age)
                .HasColumnName("Age")
                .IsRequired();
            });
        }
    }
}
