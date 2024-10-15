
namespace POS.Domain.Entities;

public class TokenEntity
{
    public string AccessToken { get; set; } = string.Empty;
    public string RefreshToken { get; set; } = string.Empty;
}
