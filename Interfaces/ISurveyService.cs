using WebSurvey.Models;

namespace WebSurvey.Interfaces;

public interface ISurveyService
{
    void SaveSurveyResponse(SurveyViewModel model);
    Statistics? Statistics();
    SurveyViewModel LoadSurveyViewModel();
}
