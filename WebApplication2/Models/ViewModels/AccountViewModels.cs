using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models.ViewModels;

// Used by ForgotPassword.cshtml
public class ForgotPasswordVM
{
    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
}

// Used by Register.cshtml
public class RegisterVM
{
    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;

    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "Passwords do not match.")]
    public string ConfirmPassword { get; set; } = string.Empty;
}

// Used by ResetPassword.cshtml
public class ResetPasswordVM
{
    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;

    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "Passwords do not match.")]
    public string ConfirmPassword { get; set; } = string.Empty;

    // token coming from the reset link
    public string? Token { get; set; }
}
