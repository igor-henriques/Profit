namespace Profit.Core;

public static class Constants
{
    public readonly struct Routes
    {
        public readonly struct Ingredient
        {
            public const string GetUnique = "api/ingredient/{id}";
            public const string GetMany = "api/ingredient";
            public const string Create = "api/ingredient";
            public const string BulkCreate = "api/ingredient";
            public const string UpdateAll = "api/ingredient/{id}";
            public const string UpdatePartially = "api/ingredient/{id}";
            public const string Delete = "api/ingredient/{id}";
        }
    }
}
