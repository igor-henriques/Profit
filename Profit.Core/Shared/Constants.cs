namespace Profit.Core.Shared;

public static class Constants
{
    public readonly struct Routes
    {
        public readonly struct Ingredient
        {
            public const string GetUnique = "api/ingredient/{guid}";
            public const string GetMany = "api/ingredient/get-many";
            public const string Create = "api/ingredient/create";
            public const string BulkCreate = "api/ingredient/bulk-create";
            public const string Put = "api/ingredient/put";
            public const string Patch = "api/ingredient/patch";
            public const string Delete = "api/ingredient/delete";
        }

        public readonly struct User
        {
            public const string GetUnique = "api/user/{guid}";
            public const string Create = "api/user/create";
            public const string Put = "api/user/put";
            public const string Delete = "api/user/delete";
            public const string Authenticate = "api/user/authenticate";
        }
    }

    public const string INGREDIENT_TAG = "Ingredient";
    public const string USER_TAG = "User";
    public const string CACHE_SERVICE_TEXT = "CacheServiceText";
}