using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrack.Components
{
    internal class Utils
    {
        public static string ROOTFOLDER = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "ExpenseTrack");
        public static string USERS = Path.Combine(ROOTFOLDER, "users.json");
        public static string TRANSACTIONS = Path.Combine(ROOTFOLDER, "transactions.json");

        public static bool ISAUTHENTICATED = false;
    }
}
