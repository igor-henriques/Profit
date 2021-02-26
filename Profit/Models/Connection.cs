using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profit.Models
{
    public class Connection
    {
        public SQLiteConnection con = new SQLiteConnection("");
        public void OpenConnection()
        {

        }
        public void CloseConnection()
        {

        }
    }
}
