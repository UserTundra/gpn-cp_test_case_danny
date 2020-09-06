using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using test_case_danny.Models;
using test_case_danny.Data;
using System.IO;

namespace test_case_danny
{
    class Program
    {
        public static readonly SQLiteConnection db = new SQLiteConnection(AppDomain.CurrentDomain.BaseDirectory + @"\test_case_danny.sqlite");

        static void Main(string[] args)
        {
            migrate();
            var data = new VisitsDatabase(db);
            var files = getAroundCSVFiles(AppDomain.CurrentDomain.BaseDirectory);
            var visits = data.ReadCSV(files);
            data.SaveToDB(visits);            
        }

        private static void migrate()
        {
            try
            {
                Program.db.CreateTable<Visits>();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }

        private static string[] getAroundCSVFiles(string rootDirectory, string fileExtension = "*.csv")
        {
            var files = Directory.GetFiles(rootDirectory, fileExtension);
            return files;
        }
    }
}
