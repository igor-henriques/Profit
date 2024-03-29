﻿namespace Profit.Core.Shared;

public static class Constants
{
    public readonly struct Routes
    {
        public readonly struct Ingredient
        {
            public const string BaseIngredient = "api/v1/ingredient";
            public const string GetUnique = $"{BaseIngredient}/get";
            public const string GetPaginated = $"{BaseIngredient}/get-paginated";
            public const string Create = $"{BaseIngredient}/create";
            public const string BulkCreate = $"{BaseIngredient}/bulk-create";
            public const string Put = $"{BaseIngredient}/put";
            public const string Delete = $"{BaseIngredient}/delete";
        }

        public readonly struct Recipe
        {
            public const string BaseRecipe = "api/v1/recipe";
            public const string GetUnique = $"{BaseRecipe}/get";
            public const string GetPaginated = $"{BaseRecipe}/get-paginated";
            public const string Create = $"{BaseRecipe}/create";
            public const string BulkCreate = $"{BaseRecipe}/bulk-create";
            public const string Put = $"{BaseRecipe}/put";
            public const string Delete = $"{BaseRecipe}/delete";
        }

        public readonly struct Product
        {
            public const string BaseProduct = "api/v1/product";
            public const string GetUnique = $"{BaseProduct}/get";
            public const string GetPaginated = $"{BaseProduct}/get-paginated";
            public const string Create = $"{BaseProduct}/create";
            public const string BulkCreate = $"{BaseProduct}/bulk-create";
            public const string Put = $"{BaseProduct}/put";
            public const string Delete = $"{BaseProduct}/delete";
        }

        public readonly struct User
        {
            public const string BaseUser = "api/v1/user";
            public const string GetUnique = $"{BaseUser}/get";
            public const string GetPaginated = $"{BaseUser}/get-paginated";
            public const string Create = $"{BaseUser}/create";
            public const string Put = $"{BaseUser}/put";
            public const string Delete = $"{BaseUser}/delete";
            public const string Authenticate = $"{BaseUser}/authenticate";
        }

        public readonly struct Order
        {
            public const string BaseOrder = "api/v1/order";
            public const string GetUnique = $"{BaseOrder}/get";
            public const string GetPaginated = $"{BaseOrder}/get-paginated";
            public const string Create = $"{BaseOrder}/create";
            public const string Put = $"{BaseOrder}/put";
            public const string Delete = $"{BaseOrder}/delete";
        }

        public const string Health = "/health";
        public const string Swagger = "/swagger";

        public readonly static string[] AllowedRoutesWithoutAuthentication = new string[]
        {
            User.Authenticate,
            User.Create,
            User.Put,
            Routes.Health,
            Routes.Swagger,
        };
    }

    public readonly struct SwaggerTags
    {
        public const string INGREDIENT = "Ingredient";
        public const string ORDER = "Order";
        public const string PRODUCT = "Product";
        public const string RECIPE = "Recipe";
        public const string USER = "User";
    }

    public readonly struct FieldsDefinitions
    {
        public const int MaxLengthDescriptions = 200;
        public const int MaxLengthImageThumbnail = 500;
        public const int MaxLengthName = 100;
        public const int MaxLengthUsername = 36;
        public const int MaxLengthHashedPassword = 256;
        public const int MaxLengthEmail = 255;
    }

    public readonly struct TableNames
    {
        public const string Ingredient = "Ingredients";
        public const string Product = "Products";
        public const string Recipe = "Recipes";
        public const string IngredientRecipeRelation = "IngredientRecipeRelations";
        public const string User = "Users";
        public const string UserClaim = "Claims";
        public const string MigrationsHistory = "__MigrationsHistory";
    }
}