namespace WebSurvey.Models;

public class Answer
{
    public string? Id { get; set; }
    public string? QuestionId { get; set; }
    public int? Choice { get; set; }
    public Question? Question { get; set; }
}