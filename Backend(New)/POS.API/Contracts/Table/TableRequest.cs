namespace POS.API.Contracts.Table;

public record TableRequest(
    int Number,
    bool IsBusy);