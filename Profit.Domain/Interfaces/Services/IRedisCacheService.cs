namespace Profit.Domain.Interfaces.Services;

/// <summary>
/// Represents a service that provides cache functionality.
/// </summary>
public interface IRedisCacheService
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
    Task<bool> Set<T>(string key, T value, TimeSpan expirationTime);

    /// <summary>
    /// Removes the value associated with the specified key.
    /// </summary>
    /// <param name="key"></param>
    void Remove(string key);

    /// <summary>
    /// Removes all keys from the current database.
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    bool Exists(string key);
}
