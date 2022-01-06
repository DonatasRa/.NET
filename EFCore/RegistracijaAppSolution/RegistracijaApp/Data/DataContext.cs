using Microsoft.EntityFrameworkCore;
using RegistracijaApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistracijaApp.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Question> Questions { get; set; }

        public DbSet<Answer> Answers { get; set; }

        public DbSet<Form> Forms { get; set; }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Question>()
            //    .HasMany(c => c.PossibleAnswers)
            //    .WithOne(e => e.Question);

            modelBuilder.Entity<Form>().HasData(
                new Form()
                {
                    Id = 1,
                    Title = "Pirmoji forma"
                });

            modelBuilder.Entity<Question>().HasData(
                new Question()
                {
                    Id = 1,
                    AnswerId = null,
                    FormId = 1,
                    Title = "Reikia atlikti rangos darbus"
                },
                new Question()
                {
                    Id = 2,
                    AnswerId = null,
                    FormId = 1,
                    Title = "Rangos darbus atliks"
                 },
                new Question()
                {
                    Id = 3,
                    AnswerId = null,
                    FormId = 1,
                    Title = "Verslo klientas"
                },
                new Question()
                {
                    Id = 4,
                    AnswerId = null,
                    FormId = 1,
                    Title = "Skaičiavimo metodas"
                },
                new Question()
                {
                    Id = 5,
                    AnswerId = null,
                    FormId = 1,
                    Title = "Svarbus klientas"
                });

            modelBuilder.Entity<Answer>().HasData(
                new Answer()
                {
                    Id = 1,
                    Value = "Taip",
                    QuestionId = 1
                },
                new Answer()
                {
                    Id = 2,
                    Value = "Ne",
                    QuestionId = 1
                },
                new Answer()
                {
                    Id = 3,
                    Value = "Metinis rangovas",
                    QuestionId = 2
                },
                new Answer()
                {
                    Id = 4,
                    Value = "Nenuolatinis rangovas",
                    QuestionId = 2
                },
                new Answer()
                {
                    Id = 5,
                    Value = "Taip",
                    QuestionId = 3
                },
                new Answer()
                {
                    Id = 6,
                    Value = "Ne",
                    QuestionId = 3
                }, new Answer()
                {
                    Id = 7,
                    Value = "Automatinis",
                    QuestionId = 4
                },
                new Answer()
                {
                    Id = 8,
                    Value = "Rankinis",
                    QuestionId = 4
                },
                new Answer()
                {
                    Id = 9,
                    Value = "Eilinis mirtingasis",
                    QuestionId = 5
                },
                new Answer()
                {
                    Id = 10,
                    Value = "VIP",
                    QuestionId = 5
                });
        }
    }
}
