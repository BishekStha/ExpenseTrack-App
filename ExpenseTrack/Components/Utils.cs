using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrack.Components
{
    internal class Utils
    {
        public static string ROOTFOLDER = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ExpenseTrack");
        public static string TRANSACTIONS = Path.Combine(ROOTFOLDER, "transaction.json");
        public static bool ISAUTHENTICATED = false;
    }
}
