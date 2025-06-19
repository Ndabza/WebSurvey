using Microsoft.EntityFrameworkCore;
using WebSurvey.Models;

namespace WebSurvey.Data;

public class SurveyContext:DbContext
{
    private IConfiguration _Configuration;
    public SurveyContext(DbContextOptions<SurveyContext> options, IConfiguration configuration) : base(options)
    {
        _Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseMySQL(_Configuration.GetConnectionString("Default")!);
    }

    public DbSet<Person> Person { get; set; }
    public DbSet<FaveriteFood> FaveriteFood { get; set; }
    public DbSet<FoodType> FoodType { get; set; }
    public DbSet<Survey> Survey { get; set; }
    public DbSet<Question> Question { get; set; }
    public DbSet<Answer> Answer {  get; set; }
    public DbSet<SurveyResponse> SurveyResponse { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ModelConfig();
        builder.Seed();
    }
}
