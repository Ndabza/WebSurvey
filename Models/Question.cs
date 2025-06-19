namespace WebSurvey.Models;

public class Question
{
    public string? Id { get; set; }
    public string? SurveyQuestion { get; set; }
    public Answer? Answer { get; set; }
    public SurveyResponse? SurveyResponse { get; set; }
}
