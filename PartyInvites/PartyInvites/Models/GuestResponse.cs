using System.ComponentModel.DataAnnotations;

namespace PartyInvites.Models;

public class GuestResponse
{
    [Required(ErrorMessage = "Please enter your name")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Please enter your email asddress")]
    [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Please enter a valid email address")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Please enter your phone namber")]
    public string? Phone { get; set; }

    [Required(ErrorMessage = "Enter specify whether you'll attent")]
    public bool? WillAttend { get; set; }
}