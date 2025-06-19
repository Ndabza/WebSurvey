using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebSurvey.Models;

public class Person
{
    public string? Id { get; set; }

    [Required]
    [DisplayName("Fullnames")]
    public string? FullNames { get; set; }

    [Required]
    [DisplayName("Email")]
    [DataType(DataType.EmailAddress)]
    public string? Email { get; set; }

    [Required]
    [AllowedAges(5, 120)]
    [DisplayName("Date of Birth")]
    [DataType(DataType.Date)]
    public DateTime DateOfBirth { get; set; }

    [Required]
    [DisplayName("Contact Number")]
    [DataType(DataType.PhoneNumber)]
    public string? ContactNumber { get; set; }

    [DisplayName("What is your favorite food?")]
    public List<FaveriteFood>? FavoriteFood { get; set; }
    public Survey? Survey { get; set; }
}