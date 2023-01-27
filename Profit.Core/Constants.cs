﻿namespace Profit.Core;

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
    }
}