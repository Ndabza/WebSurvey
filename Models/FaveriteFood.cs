namespace WebSurvey.Models
{
    public class FaveriteFood
    {
        public string? Id { get; set; }
        public string? PersonId { get; set; }
        public string? FoodTypeId { get; set; }
        public Person? Person { get; set; }
        public FoodType? FoodType { get; set; }
    }
}
