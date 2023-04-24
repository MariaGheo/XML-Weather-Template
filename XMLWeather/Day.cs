using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XMLWeather
{
    public class Day
    {
        public string date, currentTemp, currentTime, condition, icon, location, tempHigh, tempLow, windSpeed, windDirection;

        public Day()
        {
            date = currentTemp = currentTime = condition = location = tempHigh = tempLow = icon = windSpeed = windDirection = "";
        }
    }
}
