using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Xml;

/*
 * to do:
 * - round the temperature numbers - done!
 * - make the search system functional
 * - make the dates look nicer (just the day of the week, not the full date)
 */


namespace XMLWeather
{
    public partial class Form1 : Form
    {
        // TODO: create list to hold day objects
        public static List<Day> days = new List<Day>();
        public static string location = "Stratford,CA";

        public Form1()
        {
            InitializeComponent();

            ExtractForecast(location);
            ExtractCurrent(location);
            
            // open weather screen for todays weather
            CurrentScreen cs = new CurrentScreen();
            this.Controls.Add(cs);
        }

        public static void ExtractForecast(string newLocation)
        {
            days.Clear();

            XmlReader reader = XmlReader.Create("http://api.openweathermap.org/data/2.5/forecast/daily?q=" + newLocation + "&mode=xml&units=metric&cnt=7&appid=3f2e224b815c0ed45524322e145149f0");

            while (reader.Read())
            {
                //TODO: create a day object
                Day d = new Day();

                //TODO: fill day object with required data
                reader.ReadToFollowing("time");
                d.date = reader.GetAttribute("day");

                reader.ReadToFollowing("symbol");
                d.condition = reader.GetAttribute("name");
                d.icon = reader.GetAttribute("var");

                reader.ReadToFollowing("temperature");
                double tempLow = Math.Round(Convert.ToDouble(reader.GetAttribute("min")));
                d.tempLow = Convert.ToString(tempLow);
                double tempHigh = Math.Round(Convert.ToDouble(reader.GetAttribute("max")));
                d.tempHigh = Convert.ToString(tempHigh);

                //TODO: if day object not null add to the days list
                if (d.date != null)
                {
                    days.Add(d);
                }
            }

            foreach(Day day in days)
            {
                DateTime dateValue = DateTime.Parse(day.date);
                day.date = dateValue.ToString("ddd");
            }
        }

        public static void ExtractCurrent(string newLocation)
        {
            // current info is not included in forecast file so we need to use this file to get it
            XmlReader reader = XmlReader.Create("http://api.openweathermap.org/data/2.5/weather?q=" + newLocation + "&mode=xml&units=metric&appid=3f2e224b815c0ed45524322e145149f0");

            //TODO: find the city and current temperature and add to appropriate item in days list

            reader.ReadToFollowing("city");
            days[0].location = reader.GetAttribute("name");

            reader.ReadToFollowing("temperature");
            double temp = Math.Round(Convert.ToDouble(reader.GetAttribute("value")));
            days[0].currentTemp = Convert.ToString(temp);
        }
    }
}
