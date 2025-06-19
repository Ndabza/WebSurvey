using Microsoft.EntityFrameworkCore;
using WebSurvey.Models;

namespace WebSurvey.Data;

public static class DbInitializer
{
    public static void Seed(this ModelBuilder builder)
    {
        var person = new List<Person>()
        {
            new Person() {Id = "07731156-43e2-4f5e-b06f-a686df76b62b", FullNames = "Ndabenhle Ndaba", Email = "ndaba.ndabenhle@mail.com",DateOfBirth = DateTime.Parse("1997-08-26"), ContactNumber = "444555"},
            new Person() {Id = "33ed7e2d-48f1-4fdb-97e4-3fe0ede9f607", FullNames = "Sakhile Ndlovu", Email= "ndlovu.sakhile@mail.com", DateOfBirth=DateTime.Parse("1998-05-19"), ContactNumber="1112233" },
            new Person() {Id = "3950a04c-b7e5-4ded-a898-41e28b5dcb29", FullNames = "Anathi Nkosi", Email = "nkosi.anathi@mail.com", DateOfBirth = DateTime.Parse("1999-07-06"), ContactNumber = "2265598"},
            new Person() {Id = "af16d0fa-48e3-49bf-9a4c-79f737683b99", FullNames = "Thamsanqa Sibisi", Email = "sibisi.thamsanqa@mail.com", DateOfBirth = DateTime.Parse("2000-10-26"), ContactNumber = "4455864"}
        };

        foreach (var p in person)
        {
            builder.Entity<Person>().HasData(p);
        }

        var foodType = new List<FoodType>()
        {
            new FoodType(){ Id = "33a0750f-943e-46c0-8027-97709fdc4964", FoodName = "Pizza"},
            new FoodType(){ Id = "6656db56-52c3-42e2-829c-5714f13a7358", FoodName = "Pasta"},
            new FoodType(){ Id = "98081994-871b-4312-a06a-93f9651c6d38", FoodName = "Pap and Wors"},
            new FoodType(){ Id = "da1c824c-82a6-46bd-a21a-0c0a038e6172", FoodName = "Other"}
        };

        foreach (var food in foodType)
        {
            builder.Entity<FoodType>().HasData(food);
        }

        var favFood = new List<FaveriteFood>()
        {
            new FaveriteFood() { Id = "9afbcd83-8a22-46ff-b229-4d0e4f167bfc", PersonId="07731156-43e2-4f5e-b06f-a686df76b62b", FoodTypeId="6656db56-52c3-42e2-829c-5714f13a7358"},
            new FaveriteFood() { Id = "877f9631-10f9-4955-bc46-283ae50d52dc", PersonId="07731156-43e2-4f5e-b06f-a686df76b62b", FoodTypeId="98081994-871b-4312-a06a-93f9651c6d38"},
            new FaveriteFood() { Id = "819afaaa-c124-4314-adac-c36755c6b59d", PersonId="07731156-43e2-4f5e-b06f-a686df76b62b", FoodTypeId="da1c824c-82a6-46bd-a21a-0c0a038e6172"},
            new FaveriteFood() { Id = "94be6ad3-d1b7-4e50-90c1-65f1407a226d", PersonId="33ed7e2d-48f1-4fdb-97e4-3fe0ede9f607", FoodTypeId="33a0750f-943e-46c0-8027-97709fdc4964"},
            new FaveriteFood() { Id = "26b66a88-43e5-4dc7-a15b-40043ece342e", PersonId="33ed7e2d-48f1-4fdb-97e4-3fe0ede9f607", FoodTypeId="98081994-871b-4312-a06a-93f9651c6d38"},
            new FaveriteFood() { Id = "e5f745f9-a92e-49ad-9c10-dcf517af1f1f", PersonId="3950a04c-b7e5-4ded-a898-41e28b5dcb29", FoodTypeId="33a0750f-943e-46c0-8027-97709fdc4964"},
            new FaveriteFood() { Id = "a7a7d1a2-3e11-409f-a497-d361c64b3e9a", PersonId="3950a04c-b7e5-4ded-a898-41e28b5dcb29", FoodTypeId="6656db56-52c3-42e2-829c-5714f13a7358"},
            new FaveriteFood() { Id = "6d3fc311-608e-4be8-b614-5dd2028244d9", PersonId="3950a04c-b7e5-4ded-a898-41e28b5dcb29", FoodTypeId="98081994-871b-4312-a06a-93f9651c6d38"},
            new FaveriteFood() { Id = "bb8af322-55da-43b7-a465-bd157523b3ec", PersonId="3950a04c-b7e5-4ded-a898-41e28b5dcb29", FoodTypeId="da1c824c-82a6-46bd-a21a-0c0a038e6172"},
            new FaveriteFood() { Id = "91a808e2-170b-4efd-b283-3725eb3ac100", PersonId="af16d0fa-48e3-49bf-9a4c-79f737683b99", FoodTypeId="98081994-871b-4312-a06a-93f9651c6d38"},
            new FaveriteFood() { Id = "3ee6e9ce-6a5c-4a3c-943c-1c0c7149b977", PersonId="af16d0fa-48e3-49bf-9a4c-79f737683b99", FoodTypeId="33a0750f-943e-46c0-8027-97709fdc4964"},
        };

        foreach (var fav in favFood)
        {
            builder.Entity<FaveriteFood>().HasData(fav);
        }

        var survey = new List<Survey>()
        {
            new Survey(){Id="ccc21cf6-4e8d-4872-9730-cb9383b3105c",PersonId="07731156-43e2-4f5e-b06f-a686df76b62b"},
            new Survey(){Id="bdd4a411-1c29-41e3-ae62-f84758387745",PersonId="33ed7e2d-48f1-4fdb-97e4-3fe0ede9f607"},
            new Survey(){Id="f39c0c72-8415-42a4-b902-9315514a862b",PersonId="3950a04c-b7e5-4ded-a898-41e28b5dcb29"},
            new Survey(){Id="98579242-3cdd-4df1-a3f6-ea8c093cc934",PersonId="af16d0fa-48e3-49bf-9a4c-79f737683b99"}
        };

        foreach (var s in survey)
        {
            builder.Entity<Survey>().HasData(s);
        }

        var surveyQuestion = new List<Question>()
        {
            new Question(){ Id = "d10badf2-92b1-4dea-ae50-1a00afff1b22", SurveyQuestion = "I like to watch movies." },
            new Question(){ Id = "01d458f3-90d8-484c-8afb-a4da18da0cb5", SurveyQuestion = "I like to listen to radio."},
            new Question(){ Id = "20ff91ad-8fb6-43ac-af35-6b90e89b0b38", SurveyQuestion = "I like to eat out."},
            new Question(){ Id = "75ca4016-f6a8-4247-a16b-e355c8e43077", SurveyQuestion = "I like to watch TV."},
        };

        foreach (var s in surveyQuestion)
        {
            builder.Entity<Question>().HasData(s);
        }

        var surveyResponse = new List<SurveyResponse>()
        {
            new SurveyResponse(){Id ="f88603a2-4ac2-4157-804f-540507b98ea9", SurveyId="ccc21cf6-4e8d-4872-9730-cb9383b3105c",QuestionId="d10badf2-92b1-4dea-ae50-1a00afff1b22"},
            new SurveyResponse(){Id ="b986a680-cb1b-4138-804d-b0f0d9c51243", SurveyId="bdd4a411-1c29-41e3-ae62-f84758387745",QuestionId="d10badf2-92b1-4dea-ae50-1a00afff1b22"},
            new SurveyResponse(){Id ="c6684fe7-60c2-4d23-b133-780868427f96", SurveyId="f39c0c72-8415-42a4-b902-9315514a862b",QuestionId="d10badf2-92b1-4dea-ae50-1a00afff1b22"},
            new SurveyResponse(){Id ="fc7da992-8e45-4cef-b635-140d88c55cf1", SurveyId="98579242-3cdd-4df1-a3f6-ea8c093cc934",QuestionId="d10badf2-92b1-4dea-ae50-1a00afff1b22"},
            new SurveyResponse(){Id ="9f769737-6035-462c-9eea-85febaab7d86", SurveyId="ccc21cf6-4e8d-4872-9730-cb9383b3105c",QuestionId="01d458f3-90d8-484c-8afb-a4da18da0cb5"},
            new SurveyResponse(){Id ="5a85f487-9b38-46d7-9a3c-fc34bc28b4c2", SurveyId="bdd4a411-1c29-41e3-ae62-f84758387745",QuestionId="01d458f3-90d8-484c-8afb-a4da18da0cb5"},
            new SurveyResponse(){Id ="27912a65-009d-43a6-bc01-83980d4f8873", SurveyId="f39c0c72-8415-42a4-b902-9315514a862b",QuestionId="01d458f3-90d8-484c-8afb-a4da18da0cb5"},
            new SurveyResponse(){Id ="922fa0dc-11c9-4485-b509-8bb06fd3eb0b", SurveyId="98579242-3cdd-4df1-a3f6-ea8c093cc934",QuestionId="01d458f3-90d8-484c-8afb-a4da18da0cb5"},
            new SurveyResponse(){Id ="05c8c19c-e2ce-4dfd-80d4-17dec1b636c3", SurveyId="ccc21cf6-4e8d-4872-9730-cb9383b3105c",QuestionId="20ff91ad-8fb6-43ac-af35-6b90e89b0b38"},
            new SurveyResponse(){Id ="fde11fad-eeea-42ad-ba67-022f97318ed1", SurveyId="bdd4a411-1c29-41e3-ae62-f84758387745",QuestionId="20ff91ad-8fb6-43ac-af35-6b90e89b0b38"},
            new SurveyResponse(){Id ="5e63e667-fe34-4c0f-a298-c43c1aed8e38", SurveyId="f39c0c72-8415-42a4-b902-9315514a862b",QuestionId="20ff91ad-8fb6-43ac-af35-6b90e89b0b38"},
            new SurveyResponse(){Id ="d99282c7-e63e-4bb6-a6f5-73e355f31def", SurveyId="98579242-3cdd-4df1-a3f6-ea8c093cc934",QuestionId="20ff91ad-8fb6-43ac-af35-6b90e89b0b38"},
            new SurveyResponse(){Id ="f617e7ef-862b-4bf7-aa2d-34d049a24b78", SurveyId="ccc21cf6-4e8d-4872-9730-cb9383b3105c",QuestionId="75ca4016-f6a8-4247-a16b-e355c8e43077"},
            new SurveyResponse(){Id ="856b8293-6935-46b9-b75e-da0dc7125dde", SurveyId="bdd4a411-1c29-41e3-ae62-f84758387745",QuestionId="75ca4016-f6a8-4247-a16b-e355c8e43077"},
            new SurveyResponse(){Id ="d284b9f1-ab67-4db2-bb24-c2e2954685d4", SurveyId="f39c0c72-8415-42a4-b902-9315514a862b",QuestionId="75ca4016-f6a8-4247-a16b-e355c8e43077"},
            new SurveyResponse(){Id ="8dbc9e6f-b850-4807-a6f7-4b989409569e", SurveyId="98579242-3cdd-4df1-a3f6-ea8c093cc934",QuestionId="75ca4016-f6a8-4247-a16b-e355c8e43077"}
        };

        foreach (var s in surveyResponse)
        {
            builder.Entity<SurveyResponse>().HasData(s);
        }

        var answers = new List<Answer>()
        {
            new Answer(){Id="1e9de402-2f16-454e-b9ef-c3554611b40f",QuestionId="d10badf2-92b1-4dea-ae50-1a00afff1b22",Choice=1},
            new Answer(){Id="5f36ae6a-e026-435a-87fe-5447ced78b4f",QuestionId="01d458f3-90d8-484c-8afb-a4da18da0cb5",Choice=2},
            new Answer(){Id="46f1be5e-4d86-4444-a839-dade250c7b6e",QuestionId="20ff91ad-8fb6-43ac-af35-6b90e89b0b38",Choice=5},
            new Answer(){Id="28124810-f760-4f04-85a1-a15d29ccb285",QuestionId="75ca4016-f6a8-4247-a16b-e355c8e43077",Choice=3},
            new Answer(){Id="c7185c3a-76fc-4491-ab56-1205250341eb",QuestionId="d10badf2-92b1-4dea-ae50-1a00afff1b22",Choice= 3},
            new Answer(){Id="191bd139-83c0-4cc4-a968-92acde83de4d",QuestionId="01d458f3-90d8-484c-8afb-a4da18da0cb5",Choice= 2},
            new Answer(){Id="e2aa65dc-47f4-452e-8014-1b658cc38890",QuestionId="20ff91ad-8fb6-43ac-af35-6b90e89b0b38",Choice= 2},
            new Answer(){Id="e93e8e15-31c0-4b0c-b58a-43619c1abb4e",QuestionId="75ca4016-f6a8-4247-a16b-e355c8e43077",Choice= 1},
            new Answer(){Id="32e1ab9e-c4a7-407e-8683-89f86af59af6",QuestionId="d10badf2-92b1-4dea-ae50-1a00afff1b22",Choice= 2},
            new Answer(){Id="095ae3cb-6a87-4e2c-8beb-33049c76b5cd",QuestionId="01d458f3-90d8-484c-8afb-a4da18da0cb5",Choice= 3},
            new Answer(){Id="19bc8763-7bfc-4cf8-9bde-679e157af5a3",QuestionId="20ff91ad-8fb6-43ac-af35-6b90e89b0b38",Choice= 5},
            new Answer(){Id="da423657-3e2d-4b23-86ce-dae9ba1465de",QuestionId="75ca4016-f6a8-4247-a16b-e355c8e43077",Choice= 3},
            new Answer(){Id="722a577f-d7e1-49a6-bc1a-e754408c98e8",QuestionId="d10badf2-92b1-4dea-ae50-1a00afff1b22",Choice= 5},
            new Answer(){Id="70db3c34-d81a-43a3-8104-87c3f7445dbb",QuestionId="01d458f3-90d8-484c-8afb-a4da18da0cb5",Choice= 4},
            new Answer(){Id="78defed4-14a6-42bf-a07d-f3b175c941d3",QuestionId="20ff91ad-8fb6-43ac-af35-6b90e89b0b38",Choice= 4},
            new Answer(){Id="e912d393-93a0-4180-b1ef-3d745483d730",QuestionId="75ca4016-f6a8-4247-a16b-e355c8e43077",Choice= 3},
        };

        foreach (var answer in answers)
        {
            builder.Entity<Answer>().HasData(answer);
        }
    }
}
