﻿namespace Profit.Core.Shared;

public static class ArgumentValidator
{
    public static void ThrowIfNullOrEmpty(string argument, string paramName = null)
    {
        if (string.IsNullOrEmpty(argument))
        {
            throw new System.ArgumentException($"{paramName ?? "Argument"} cannot be null or empty", paramName);
        }
    }

    public static void ThrowIfNegative<T>(T argument, string paramName = null) where T : INumber<T>
    {
        if (argument < T.Zero)
        {
            throw new System.ArgumentException($"{paramName ?? "Argument"} cannot be negative");
        }
    }

    public static void ThrowIfZero<T>(T argument, string paramName = null) where T : INumber<T>
    {
        if (argument == T.Zero)
        {
            throw new System.ArgumentException($"{paramName ?? "Argument"} cannot be zero");
        }
    }

    public static void ThrowIfNullOrDefault<T>(T obj, string paramName = null) where T : new()
    {
        if (obj.Equals(default(T)) | obj == null)
        {
            throw new System.ArgumentException($"{paramName ?? "Argument"} cannot be null or default");
        }
    }
}
