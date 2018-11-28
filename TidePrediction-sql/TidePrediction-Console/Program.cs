using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using TidePrediction_Library;

namespace TidePrediction_Console
{
    class Program
    {
    
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

     
            string currentDir = Directory.GetCurrentDirectory();
        
            string dbPath = currentDir + @"/../../../../TidePrediction/Assets/tides.db3";
            var db = new SQLiteConnection(dbPath);

            // Create a Stocks table
            db.DropTable<TidePrediction>();
            if (db.CreateTable<TidePrediction>() == 0)
            {
                // A table already exixts, delete any data it contains
                db.DeleteAll<TidePrediction>();
            }

            AddTidePredictionToDb(db, currentDir + @" /../../../../TidePrediction-sql/Assets/florence.xml", "Florence");
            AddTidePredictionToDb(db, currentDir + @"/../../../../TidePrediction-sql/Assets/newport.xml", "Newport");
            AddTidePredictionToDb(db, currentDir + @"/../../../../TidePrediction-sql/Assets/astoria.xml", "Astoria");
        }

        private static void AddTidePredictionToDb(SQLiteConnection db, string city, string file)
        {

            XmlTideFileParser reader = new XmlTideFileParser(File.Open(@file, FileMode.Open));
            List<IDictionary<string, object>> tideList = reader.TideList;

            int pk = 0;
            string date;
            string day;
            string time;
            string height;
            string high_low;


            foreach (IDictionary<string, object> prediction in tideList)
            {            

                date = (string)prediction["date"];
                day = (string)prediction["day"];
                time = (string)prediction["time"];
                height = (string)prediction["pred_in_ft"];
                high_low = (string)prediction["highlow"];

                pk += db.Insert(new TidePrediction(city, date, day, time, height, high_low)
                {
                    City = city,
                    Date = date,
                    Day = day,
                    Time = time,
                    Height = height,
                    Hi_Low = high_low          
                });
            }

            Console.WriteLine("{0} {1} finished", city, pk);


        }
    }
}
