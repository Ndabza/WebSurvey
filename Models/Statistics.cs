using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;

namespace WebSurvey.Models
{
    public class Statistics
    {
        [DisplayName("Total number of surveys")]
        public int TotalNumberOfSurveys {  get; set; }

        [DisplayName("Average Age")]
        public int AverageAge { get; set; }

        [DisplayName("Oldest person who participated")]
        public int OldestPersonWhoParticipated {  get; set; }

        [DisplayName("Youngest person who participated")]
        public int YoungestPersonWhoParticipated { get; set; }

        [DisplayName("Percentage of people who like Pizza")]
        public int PercentageOfPeopleWhoLikePizza {  get; set; }

        [DisplayName("Percentage of people who like Pasta")]
        public int PercentageOfPeopleWhoLikePasta {  get; set; }

        [DisplayName("Percentage of people who like Pap and Wors")]
        public int PercentageOfPeopleWhoLikePapandWors {  get; set; }

        [DisplayName("People who like to watch Movies")]
        public int PeopleWhoLikeToWatchMovies { get; set; }

        [DisplayName("People who like to listen to Radio")]
        public int PeopleWhoLikeToListenToRadio { get; set; }

        [DisplayName("People who like to eat out")]
        public int PeopleWhoLikeToEatOut { get; set; }

        [DisplayName("People who like to watch TV")]
        public int PeopleWhoLikeToWatchTV { get; set; }
    }
}
