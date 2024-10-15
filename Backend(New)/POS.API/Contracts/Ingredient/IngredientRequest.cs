namespace POS.API.Contracts.Ingredient;

public record IngredientRequest(
    string Name,
    decimal Quantity,
    decimal UnitPrice);