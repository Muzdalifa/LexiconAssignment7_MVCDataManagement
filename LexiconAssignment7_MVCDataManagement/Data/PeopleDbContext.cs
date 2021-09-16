using LexiconAssignment7_MVCDataManagement.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconAssignment7_MVCDataManagement.Data
{
    public class PeopleDbContext:IdentityDbContext
    {
        public PeopleDbContext(DbContextOptions<PeopleDbContext> options):base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PersonLanguage>().HasKey(ky =>
            new
            {
                ky.LanguageID,
                ky.PersonID
            });

            modelBuilder.Entity<PersonLanguage>()
                .HasOne<Person>(ky => ky.Person)
                .WithMany(k => k.PersonLanguages)
                .HasForeignKey(ky => ky.PersonID);

            modelBuilder.Entity<PersonLanguage>()
                .HasOne<Language>(ky => ky.Language)
                .WithMany(y => y.PersonLanguages)
                .HasForeignKey(ky => ky.LanguageID);
        }

        public DbSet<Person> People { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<PersonLanguage> PersonLanguages { get; set; }
    }
}
