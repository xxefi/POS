namespace POS.Domain.Abstractions.Services;

public interface IBlackListService
{
    bool IsTokenBlackListed(string token);
    void AddTokenToBlackList(string token);
}
