namespace WebSurvey.Models;

public class SurveyResponse
{
    public string? Id { get; set; }
    public string? SurveyId { get; set; }
    public string? QuestionId { get; set; }
    public Survey? Survey { get; set; }
    public Question? Question { get; set; }
}