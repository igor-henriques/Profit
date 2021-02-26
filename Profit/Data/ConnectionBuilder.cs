using System.IO;

namespace Profit.Data
{
    public class ConnectionBuilder
    {
        public static string GetConnectionString()
        {
            return @"Data Source=" + Directory.GetCurrentDirectory() + @"\database.db"; ;
        }
    }
}
