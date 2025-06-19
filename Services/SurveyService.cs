using System.Linq;
using WebSurvey.Data;
using WebSurvey.Interfaces;
using WebSurvey.Models;

namespace WebSurvey.Services;

public class SurveyService : ISurveyService
{
    private SurveyContext _surveyContext;

    public SurveyService(SurveyContext surveyContext)
    {
        _surveyContext = surveyContext;
    }

    public SurveyViewModel LoadSurveyViewModel()
    {
        try
        {
            var viewModel = new SurveyViewModel()
            {
                FoodTypeList = _surveyContext.FoodType.ToList(),
                Questions = _surveyContext.Question.ToList(),
            };

            return viewModel;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public void SaveSurveyResponse(SurveyViewModel model)
    {
        try
        {
            using var transaction = _surveyContext.Database.BeginTransaction();

            string[] question1 = model.QuestionView!.Question1!.Split(",");
            string[] question2 = model.QuestionView!.Question2!.Split(",");
            string[] question3 = model.QuestionView!.Question3!.Split(",");
            string[] question4 = model.QuestionView!.Question4!.Split(",");

            _surveyContext.Person.Add(model.Person!);
            _surveyContext.SaveChanges();

            var faveriteFood = new List<FaveriteFood>();

            foreach (var food in model.FoodList!)
            {
                faveriteFood.Add(new FaveriteFood { PersonId = model.Person!.Id, FoodTypeId = food });

            }

            _surveyContext.FaveriteFood.AddRange(faveriteFood);
            _surveyContext.SaveChanges();

            var survey = new Survey()
            {
                PersonId = model.Person?.Id
            };

            _surveyContext.Survey.Add(survey);
            _surveyContext.SaveChanges();

            var surveyResponse = new List<SurveyResponse>()
            {
                new SurveyResponse(){SurveyId = survey.Id, QuestionId = question1[1]},
                new SurveyResponse(){SurveyId = survey.Id, QuestionId = question2[1]},
                new SurveyResponse(){SurveyId = survey.Id, QuestionId = question3[1]},
                new SurveyResponse(){SurveyId = survey.Id, QuestionId = question4[1]}
            };

            _surveyContext.SurveyResponse.AddRange(surveyResponse);
            _surveyContext.SaveChanges();

            var answer = new List<Answer>()
            {
                new Answer { QuestionId=question1[1], Choice = Convert.ToInt32(question1[0])},
                new Answer { QuestionId=question2[1], Choice = Convert.ToInt32(question2[0])},
                new Answer { QuestionId=question3[1], Choice = Convert.ToInt32(question3[0])},
                new Answer { QuestionId=question4[1], Choice = Convert.ToInt32(question4[0])}
            };

            _surveyContext.Answer.AddRange(answer);
            _surveyContext.SaveChanges();

            transaction.Commit();
            transaction.Dispose();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public Statistics? Statistics()
    {
        try
        {
            var people = _surveyContext.Person.ToList();
            var surveys = _surveyContext.Survey.ToList();
            var questions = _surveyContext.Question.ToList();
            var faveriteFood = _surveyContext.FaveriteFood.ToList();
            var foodList = _surveyContext.FoodType.ToList();
            var answers = _surveyContext.Answer.ToList();

            var ageList = AgeList(people);
            var averageAge = (ageList.Sum()) / (ageList.Count());

            var surveyCount = surveys.Count;

            var pizzaId = foodList.FirstOrDefault(x => x.FoodName == "Pizza")!.Id;
            var pastaId = foodList.FirstOrDefault(x => x.FoodName == "Pasta")!.Id;
            var papAndWorsId = foodList.FirstOrDefault(x => x.FoodName == "Pap and Wors")!.Id;

            var question1Id = questions.FirstOrDefault(x => x.SurveyQuestion == "I like to watch movies.")!.Id;
            var question2Id = questions.FirstOrDefault(x => x.SurveyQuestion == "I like to listen to radio.")!.Id;
            var question3Id = questions.FirstOrDefault(x => x.SurveyQuestion == "I like to eat out.")!.Id;
            var question4Id = questions.FirstOrDefault(x => x.SurveyQuestion == "I like to watch TV.")!.Id;

            decimal pizzaPercentage = Convert.ToDecimal(faveriteFood.Where(x => x.FoodTypeId == pizzaId).Count())
                / Convert.ToDecimal(surveyCount) * 100m;
            decimal pastaPercentage = Convert.ToDecimal(faveriteFood.Where(x => x.FoodTypeId == pastaId).Count())
                / Convert.ToDecimal(surveyCount) * 100m;
            decimal papAndWorsPercentage = Convert.ToDecimal(faveriteFood.Where(x => x.FoodTypeId == papAndWorsId).Count())
                / Convert.ToDecimal(surveyCount) * 100m;

            var statistics = new Statistics();

            statistics.TotalNumberOfSurveys = surveyCount;
            statistics.AverageAge = Convert.ToInt32(averageAge);
            statistics.OldestPersonWhoParticipated = ageList.Max();
            statistics.YoungestPersonWhoParticipated = ageList.Min();

            statistics.PercentageOfPeopleWhoLikePizza = ((int)Math.Round(pizzaPercentage));
            statistics.PercentageOfPeopleWhoLikePasta = ((int)Math.Round(pastaPercentage));
            statistics.PercentageOfPeopleWhoLikePapandWors = ((int)Math.Round(papAndWorsPercentage));

            statistics.PeopleWhoLikeToWatchMovies = AverageOfRating(answers, question1Id!);
            statistics.PeopleWhoLikeToListenToRadio = AverageOfRating(answers, question2Id!);
            statistics.PeopleWhoLikeToEatOut = AverageOfRating(answers, question3Id!);
            statistics.PeopleWhoLikeToWatchTV = AverageOfRating(answers, question4Id!);

            return statistics;
        }
        catch (Exception)
        {
            throw;
        }
    }

    private List<int> AgeList(List<Person> people)
    {
        var age = new List<int>();

        foreach (var person in people)
        {
            age.Add(Convert.ToInt32(DateTime.Now.Year) - Convert.ToInt32(person.DateOfBirth.Year));
        }

        return age;
    }

    private int AverageOfRating(List<Answer> answers, string id)
    {
        var individualRating = answers.Where(x => x.QuestionId == id);
        int ratingCount = individualRating.Count();
        var rating = new List<int>();

        foreach (var rate in individualRating)
        {
            rating.Add(Convert.ToInt32(rate.Choice));
        }

        return Convert.ToInt32(rating.Sum() / ratingCount);
    }

}
