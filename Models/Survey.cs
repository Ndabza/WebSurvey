namespace WebSurvey.Models;

public class Survey
{
    public string? Id { get; set; }
    public string? PersonId { get; set; }
    public Person? Person { get; set; }
    public List<SurveyResponse>? SurveyResponse { get; set; }
}
