namespace Profit.Core.Shared;

public static class Constants
{
    public readonly struct Routes
    {
        public readonly struct Ingredient
        {
            public const string GetUnique = "api/v1/ingredient/get";
            public const string GetMany = "api/v1/ingredient/get-many";
            public const string Create = "api/v1/ingredient/create";
            public const string BulkCreate = "api/v1/ingredient/bulk-create";
            public const string Put = "api/v1/ingredient/put";
            public const string Patch = "api/v1/ingredient/patch";
            public const string Delete = "api/v1/ingredient/delete";
        }

        public readonly struct Recipe
        {
            public const string GetUnique = "api/v1/recipe/get";
            public const string GetMany = "api/v1/recipe/get-many";
            public const string Create = "api/v1/recipe/create";
            public const string BulkCreate = "api/v1/recipe/bulk-create";
            public const string Put = "api/v1/recipe/put";
            public const string Patch = "api/v1/recipe/patch";
            public const string Delete = "api/v1/recipe/delete";
        }

        public readonly struct Product
        {
            public const string GetUnique = "api/v1/product/get";
            public const string GetMany = "api/v1/product/get-many";
            public const string Create = "api/v1/product/create";
            public const string BulkCreate = "api/v1/product/bulk-create";
            public const string Put = "api/v1/product/put";
            public const string Patch = "api/v1/product/patch";
            public const string Delete = "api/v1/product/delete";
        }

        public readonly struct User
        {
            public const string GetUnique = "api/v1/user/get";
            public const string GetMany = "api/v1/user/get-many";
            public const string Create = "api/v1/user/create";
            public const string BulkCreate = "api/v1/user/bulk-create";
            public const string Put = "api/v1/user/put";
            public const string Patch = "api/v1/user/patch";
            public const string Delete = "api/v1/user/delete";
            public const string Authenticate = "api/v1/user/authenticate";
        }
    }

    public readonly struct SwaggerTags
    {
        public const string INGREDIENT = "Ingredient";
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
}