namespace Profit.Infrastructure.Repository.Repositories.Scripts;

internal static class TablesDDLQueries
{
    private const string INGREDIENTS_QUERY = """
            CREATE TABLE [dbo].[Ingredients] (
            [Id] uniqueidentifier NOT NULL,
            [Name] nvarchar(100) NOT NULL,
            [Price] decimal(18,2) NOT NULL,
            [MeasurementUnitType] tinyint NOT NULL,
            [Quantity] decimal(18,2) NOT NULL,
            [ImageThumbnailUrl] nvarchar(500) NOT NULL,
            [Description] nvarchar(200) NULL,
            CONSTRAINT [PK_Ingredients] PRIMARY KEY ([Id])
            );
        """;
    private const string INGREDIENTS_RECIPE_QUERY = """
            CREATE TABLE [dbo].[IngredientRecipeRelations] (
            [IngredientId] uniqueidentifier NOT NULL,
            [RecipeId] uniqueidentifier NOT NULL,
            [MeasurementUnit] tinyint NOT NULL,
            [IngredientCount] decimal(18,2) NOT NULL,
            [Id] uniqueidentifier NOT NULL,
            CONSTRAINT [PK_IngredientRecipeRelations] PRIMARY KEY ([IngredientId], [RecipeId]),
            CONSTRAINT [FK_IngredientRecipeRelations_Ingredients_IngredientId] FOREIGN KEY ([IngredientId]) REFERENCES [dbo].[Ingredients] ([Id]) ON DELETE CASCADE,
            CONSTRAINT [FK_IngredientRecipeRelations_Recipes_RecipeId] FOREIGN KEY ([RecipeId]) REFERENCES [dbo].[Recipes] ([Id]) ON DELETE CASCADE
        );
        """;
    private const string PRODUCTS_QUERY = """
            CREATE TABLE [dbo].[Products] (
            [Id] uniqueidentifier NOT NULL,
            [Name] nvarchar(100) NOT NULL,
            [TotalPrice] decimal(18,2) NOT NULL,
            [ImageThumbnailUrl] nvarchar(500) NOT NULL,
            [Description] nvarchar(200) NULL,
            [RecipeId] uniqueidentifier NOT NULL,
            CONSTRAINT [PK_Products] PRIMARY KEY ([Id]),
            CONSTRAINT [FK_Products_Recipes_RecipeId] FOREIGN KEY ([RecipeId]) REFERENCES [dbo].[Recipes] ([Id]) ON DELETE CASCADE
        );
        """;
    private const string RECIPES_QUERY = """
            CREATE TABLE [dbo].[Recipes] (
            [Id] uniqueidentifier NOT NULL,
            [Name] nvarchar(50) NOT NULL,
            [TotalCost] decimal(18,2) NOT NULL,
            [Description] nvarchar(200) NULL,
            CONSTRAINT [PK_Recipes] PRIMARY KEY ([Id])
        );
        """;
    private const string INDEXES_QUERY = """
            CREATE INDEX [IX_IngredientRecipeRelations_RecipeId] ON [dbo].[IngredientRecipeRelations] ([RecipeId]);
            CREATE INDEX [IX_Products_RecipeId] ON [dbo].[Products] ([RecipeId]);
        """;
    private const string DropTableQuery = """
            IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = '{0}' AND TABLE_SCHEMA = '{1}')
        BEGIN
            DROP TABLE [{1}].[{0}];
        END
        """;

    public static string GetIngredientsDefinition => INGREDIENTS_QUERY.Replace("dbo", "{0}");
    public static string GetIngredientsRecipeDefinition => INGREDIENTS_RECIPE_QUERY.Replace("dbo", "{0}");
    public static string GetProductsDefinition => PRODUCTS_QUERY.Replace("dbo", "{0}");
    public static string GetRecipesDefinition => RECIPES_QUERY.Replace("dbo", "{0}");
    public static string GetIndexesQuery => INDEXES_QUERY.Replace("dbo", "{0}");
    public static string GetDropTableQuery(string tableName, string schemaName) => string.Format(DropTableQuery, tableName, schemaName);
}