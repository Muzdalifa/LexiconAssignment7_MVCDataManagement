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

        public DbSet<Person> People { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<PersonLanguage> PersonLanguages { get; set; }
        public DbSet<ApplicationUser> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PersonLanguage>().HasKey(ky =>
            new
            {
                ky.LanguageId,
                ky.PersonId
            });

            modelBuilder.Entity<PersonLanguage>()
                .HasOne<Person>(ky => ky.Person)
                .WithMany(k => k.PersonLanguages)
                .HasForeignKey(ky => ky.PersonId);

            modelBuilder.Entity<PersonLanguage>()
                .HasOne<Language>(ky => ky.Language)
                .WithMany(y => y.PersonLanguages)
                .HasForeignKey(ky => ky.LanguageId);

            //seeding database
            //seeding country
            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 1, Name = "Tanzania" });
            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 2, Name = "Sweden" });
            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 3, Name = "Kenya" });
            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 4, Name = "Uganda" });
            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 5, Name = "Germany" });

            //seeding Cities
            modelBuilder.Entity<City>().HasData(new City { CityId = 1, Name = "Dar es salaam", CountryId = 1 });
            modelBuilder.Entity<City>().HasData(new City { CityId = 2, Name = "Dodoma", CountryId = 1 });
            modelBuilder.Entity<City>().HasData(new City { CityId = 3, Name = "Uppsala", CountryId = 2 });
            modelBuilder.Entity<City>().HasData(new City { CityId = 4, Name = "Stockholm", CountryId = 2 });
            modelBuilder.Entity<City>().HasData(new City { CityId = 5, Name = "Nairobi", CountryId = 3 });
            modelBuilder.Entity<City>().HasData(new City { CityId = 6, Name = "Kampala", CountryId = 4 });
            modelBuilder.Entity<City>().HasData(new City { CityId = 7, Name = "	Munich", CountryId = 5 });

            //seeding languages
            modelBuilder.Entity<Language>().HasData(new Language { LanguageId = 1, Name = "Swahili" });
            modelBuilder.Entity<Language>().HasData(new Language { LanguageId = 2, Name = "Swedish" });
            modelBuilder.Entity<Language>().HasData(new Language { LanguageId = 3, Name = "English" });
            modelBuilder.Entity<Language>().HasData(new Language { LanguageId = 4, Name = "Spanish" });
            modelBuilder.Entity<Language>().HasData(new Language { LanguageId = 5, Name = "Arabic" });
            modelBuilder.Entity<Language>().HasData(new Language { LanguageId = 6, Name = "Chinese" });

            //seeding languages
            modelBuilder.Entity<Person>().HasData(new Person { PersonId = 1, Name = "Muzda", CityId=1, PhoneNumber= "+46700276515"});
      
        }
    }

}
