namespace Profit.Domain.Models;

public sealed record MeasurementUnit
{
    private readonly EMeasurementUnit _measurementUnit;
    public decimal Quantity { get; init; }
    public string TranslatedName { get => _measurementUnitTranslator.GetValueOrDefault(_measurementUnit); }
    public string Abbreviation { get => _measurementAbbreviationTranslator.GetValueOrDefault(_measurementUnit); }

    private readonly static ImmutableDictionary<EMeasurementUnit, string> _measurementUnitTranslator;
    private readonly static ImmutableDictionary<EMeasurementUnit, string> _measurementAbbreviationTranslator;

    static MeasurementUnit()
    {
        var dictionaryBuilder = ImmutableDictionary.CreateBuilder<EMeasurementUnit, string>();

        dictionaryBuilder.Add(EMeasurementUnit.Milligram, "Miligrama");
        dictionaryBuilder.Add(EMeasurementUnit.Gram, "Grama");
        dictionaryBuilder.Add(EMeasurementUnit.Kilogram, "Kilograma");
        dictionaryBuilder.Add(EMeasurementUnit.Milliliter, "Mililitro");
        dictionaryBuilder.Add(EMeasurementUnit.Liter, "Litro");

        _measurementUnitTranslator = dictionaryBuilder.ToImmutable();

        var abbreviationdictionaryBuilder = ImmutableDictionary.CreateBuilder<EMeasurementUnit, string>();

        abbreviationdictionaryBuilder.Add(EMeasurementUnit.Milligram, "Mg");
        abbreviationdictionaryBuilder.Add(EMeasurementUnit.Gram, "g");
        abbreviationdictionaryBuilder.Add(EMeasurementUnit.Kilogram, "Kg");
        abbreviationdictionaryBuilder.Add(EMeasurementUnit.Milliliter, "Ml");
        abbreviationdictionaryBuilder.Add(EMeasurementUnit.Liter, "L");

        _measurementAbbreviationTranslator = abbreviationdictionaryBuilder.ToImmutable();
    }

    private MeasurementUnit(EMeasurementUnit measurementUnit, decimal quantity)
    {
        _measurementUnit = measurementUnit;
        Quantity = quantity;
    }

    public static MeasurementUnit Create(EMeasurementUnit measurementUnit, decimal quantity)
    {
        ArgumentValidator.ThrowIfZero(quantity, nameof(quantity));
        ArgumentValidator.ThrowIfNegative(quantity, nameof(quantity));
        return new MeasurementUnit(measurementUnit, quantity);
    }

    public static MeasurementUnit CreateFromIngredient(Ingredient ingredient)
    {
        ArgumentValidator.ThrowIfNullOrDefault(ingredient, nameof(ingredient));
        return new MeasurementUnit(ingredient.MeasurementUnit, ingredient.Quantity);
    }

    public static MeasurementUnit CreateFromIngredientRecipeRelation(IngredientRecipeRelation ingredientRecipeRelation)
    {
        ArgumentValidator.ThrowIfNullOrDefault(ingredientRecipeRelation, nameof(ingredientRecipeRelation));
        return new MeasurementUnit(ingredientRecipeRelation.Ingredient.MeasurementUnit, ingredientRecipeRelation.IngredientCount);
    }

    /// <summary>
    /// Converts the provided unit to the provided unit type.
    /// </summary>
    /// <param name="fromUnit"></param>
    /// <param name="toUnit"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException">Exception thrown when the units are not compatible.</exception>
    public static MeasurementUnit GetEquivalent(MeasurementUnit fromUnit, EMeasurementUnit toUnit)
    {
        return fromUnit._measurementUnit switch
        {
            EMeasurementUnit.Milligram when toUnit is EMeasurementUnit.Gram => new MeasurementUnit(EMeasurementUnit.Gram, fromUnit.Quantity / 100m),
            EMeasurementUnit.Milligram when toUnit is EMeasurementUnit.Kilogram => new MeasurementUnit(EMeasurementUnit.Kilogram, fromUnit.Quantity / 1_000_000m),
            EMeasurementUnit.Gram when toUnit is EMeasurementUnit.Milligram => new MeasurementUnit(EMeasurementUnit.Milligram, fromUnit.Quantity * 1_000m),
            EMeasurementUnit.Gram when toUnit is EMeasurementUnit.Kilogram => new MeasurementUnit(EMeasurementUnit.Kilogram, fromUnit.Quantity / 1_000m),
            EMeasurementUnit.Kilogram when toUnit is EMeasurementUnit.Milligram => new MeasurementUnit(EMeasurementUnit.Milligram, fromUnit.Quantity * 1_000_000m),
            EMeasurementUnit.Kilogram when toUnit is EMeasurementUnit.Gram => new MeasurementUnit(EMeasurementUnit.Gram, fromUnit.Quantity * 1_000m),
            EMeasurementUnit.Milliliter when toUnit is EMeasurementUnit.Liter => new MeasurementUnit(EMeasurementUnit.Liter, fromUnit.Quantity / 1_000m),
            EMeasurementUnit.Liter when toUnit is EMeasurementUnit.Milliliter => new MeasurementUnit(EMeasurementUnit.Liter, fromUnit.Quantity * 1_000m),
            _ => throw new InvalidOperationException("This conversion is not supported.")
        };
    }
}