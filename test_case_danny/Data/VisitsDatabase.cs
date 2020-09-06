using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using test_case_danny.Models;
using System.IO;
using System.Data;
using System.Globalization;
using System.Text.RegularExpressions;

namespace test_case_danny.Data
{
    class VisitsDatabase
    {
        private readonly SQLiteConnection db;

        public VisitsDatabase(SQLiteConnection db)
        {
            this.db = db;
        }

        public List<Visits> ReadCSV(string[] path)
        {
            List<Visits> visits = new List<Visits>();

            foreach (var item in path)
            {
                try
                {
                    visits.AddRange(this.ReadCSV(item));
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                
            }

            return visits;
        }

        public List<Visits> ReadCSV(string path)
        {
            using (var reader = new StreamReader(path))
            {
                List<Visits> visits = new List<Visits>();
                if (!reader.EndOfStream)
                    reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    for (int i = 0; i < values.Length; i++)
                    {
                        values[i] = values[i].Trim('"');
                    }

                    var timeStamp = Convert.ToDateTime(values[0]);

                    var visit = new Visits()
                    {
                        LogDate = timeStamp.ToString("dd.MM.yyyy"),
                        LogTime = timeStamp.ToString("HH:mm:ss"),
                        UserLogin = values[1].Split('|').Last(),
                        ServerUrl = values[2],
                        SiteUrl = values[3],
                        WebUrl = values[4],
                        DocumentPath = values[5]
                    };

                    visits.Add(visit);
                }

                return visits;
            }
        }

        public void SaveToDB(List<Visits> visits)
        {
            try
            {
                db.InsertAll(visits);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Can`t insert rows to database");
            }
            
        }
        
    }
}
