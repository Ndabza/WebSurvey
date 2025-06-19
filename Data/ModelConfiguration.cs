using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using WebSurvey.Models;

namespace WebSurvey.Data;

public static class ModelConfiguration
{
    public static void ModelConfig(this ModelBuilder builder)
    {
        builder.Entity<Person>(x =>
        {
            x.HasKey(x => x.Id);
            x.Property(x => x.Id).ValueGeneratedOnAdd().HasMaxLength(128).IsRequired();
            x.Property(x => x.FullNames).HasMaxLength(100).IsRequired();
            x.Property(x => x.Email).HasMaxLength(255).IsRequired();
            x.Property(x => x.ContactNumber).HasMaxLength(15).IsRequired();
            x.HasOne(x => x.Survey).WithOne(x => x.Person).HasForeignKey<Survey>(x => x.PersonId);
        });

        builder.Entity<Survey>(x =>
        {
            x.HasKey(x => x.Id);
            x.Property(x => x.Id).ValueGeneratedOnAdd().HasMaxLength(128).IsRequired();
            x.Property(x => x.PersonId).IsRequired();
        });

        builder.Entity<SurveyResponse>(x =>
        {
            x.HasKey(x => x.Id);
            x.Property(x => x.Id).ValueGeneratedOnAdd().HasMaxLength(128).IsRequired();
            x.HasOne(x=>x.Survey).WithMany(x=>x.SurveyResponse).HasForeignKey(x=>x.SurveyId);
            x.HasOne(x => x.Question).WithOne(x => x.SurveyResponse).HasForeignKey<SurveyResponse>(x => x.QuestionId);
        });

        builder.Entity<Question>(x =>
        {
            x.HasKey(x => x.Id);
            x.Property(x => x.Id).ValueGeneratedOnAdd().HasMaxLength(128).IsRequired();
            x.Property(x => x.SurveyQuestion).HasMaxLength(254).IsRequired();
            x.Property(x => x.Id).ValueGeneratedOnAdd().HasMaxLength(128).IsRequired();
        });

        builder.Entity<Answer>(x =>
        {
            x.HasKey(x => x.Id);
            x.Property(x => x.Id).ValueGeneratedOnAdd().HasMaxLength(128).IsRequired();
            x.Property(x => x.QuestionId).IsRequired();
            x.Property(x => x.Choice).IsRequired();
            x.HasOne(x => x.Question).WithOne(x => x.Answer).HasForeignKey<Answer>(x => x.QuestionId);

        });

        builder.Entity<FaveriteFood>(x =>
        {
            x.HasKey(x => x.Id);
            x.Property(x => x.Id).ValueGeneratedOnAdd().HasMaxLength(128).IsRequired();
            x.Property(x => x.PersonId).IsRequired();
            x.Property(x => x.FoodTypeId).IsRequired();
            x.HasOne(x => x.Person).WithMany(x => x.FavoriteFood).HasForeignKey(x => x.PersonId);
        });

        builder.Entity<FoodType>(x =>
        {
            x.HasKey(x => x.Id);
            x.Property(x => x.Id).ValueGeneratedOnAdd().HasMaxLength(128).IsRequired();
            x.Property(x => x.FoodName).HasMaxLength(50).IsRequired();
            x.HasOne(x => x.FaveriteFood).WithOne(x => x.FoodType).HasForeignKey<FaveriteFood>(x => x.FoodTypeId);
        });
    }
}
