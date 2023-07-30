namespace Profit.Domain.Interfaces.Services;

/// <summary>
/// Represents a service that provides cache functionality.
/// </summary>
public interface ICacheService
{
    /// <summary>
    /// Gets the value associated with the specified key.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key"></param>
    /// <returns></returns>
    Task<T> GetAsync<T>(string key);

    /// <summary>
    /// Sets the value associated with the specified key.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <param name="expirationTime"></param>
    /// <returns></returns>
    Task<bool> SetAsync<T>(string key, T value, TimeSpan expirationTime);

    /// <summary>
    /// Removes the value associated with the specified key.
    /// </summary>
    /// <param name="key"></param>
    void Remove(string key);

    /// <summary>
    /// Removes all keys from the current data
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    bool Exists(string key);

    /// <summary>
    /// Build a custom redis key
    /// </summary>
    /// <param name="keys"></param>
    /// <returns></returns>
    public static string GetCustomKey(params string[] keys)
    {
        if ((keys?.Length ?? 0) == 0)
        {
            return string.Empty;
        }

        StringBuilder sb = new();

        for (int i = 0; i < keys.Length; i++)
        {
            if (string.IsNullOrWhiteSpace(keys[i]))
            {
                continue;
            }

            sb.Append(keys[i]);

            if (i != keys.Length - 1)
            {
                sb.Append(':');
            }
        }

        return sb.ToString().ToLower();
    }
}
