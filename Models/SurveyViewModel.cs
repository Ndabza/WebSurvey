using System.ComponentModel.DataAnnotations;

namespace WebSurvey.Models;

public class SurveyViewModel
{
    public QuestionView? QuestionView { get; set; }
    public Person? Person { get; set; }
    public List<Question>? Questions { get; set; } = new List<Question>();
    public List<FoodType>? FoodTypeList { get; set; } = new List<FoodType>();

    [MinList()]
    public List<string>? FoodList { get; set; } = new List<string>();
}

public class QuestionView
{
    [Required(ErrorMessage = "*")]   
    public string? Question1 { get; set; }
    [Required(ErrorMessage = "*")]
    public string? Question2 { get; set; }
    [Required(ErrorMessage = "*")]
    public string? Question3 { get; set; }
    [Required(ErrorMessage = "*")]
    public string? Question4 { get; set; }
}
