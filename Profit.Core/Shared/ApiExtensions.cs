namespace Profit.Core.Shared;

public static class ApiExtensions
{
    public static string CreateUri(this string getPath, Guid resource)
        => getPath.Concat($"?guid={resource}").ToString();
}
