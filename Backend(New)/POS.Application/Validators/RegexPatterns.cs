
namespace POS.Application.Validators;

public class RegexPatterns
{
    public const string usernamePattern = @"(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.*[_*&%$#@]).{5,}";
    public const string passwordPattern = @"(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.*[_*&%$#@!]).{8,}";
    public const string namePattern = @"^[A-Za-z0-9\s]{2,50}$";
    public const string phonePattern = @"^\+?[1-9]\d{1,14}$";
    public const string descriptionPattern = @"^[A-Za-z0-9\s\.,!?]{10,200}$";
}
