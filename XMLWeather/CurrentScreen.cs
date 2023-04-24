using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XMLWeather
{
    public partial class CurrentScreen : UserControl
    {
        public CurrentScreen()
        {
            InitializeComponent();
            DisplayCurrent();
        }

        public void DisplayCurrent()
        {
            cityOutput.Text = Form1.days[0].location;
            dateOutput.Text = Form1.days[0].date;
            tempOutput.Text = Form1.days[0].currentTemp + "°C";
            minOutput.Text = Form1.days[0].tempLow + "°C";
            maxOutput.Text = Form1.days[0].tempHigh + "°C";

            switch (Form1.days[0].icon)
            {
                case "01d":
                    currentPictureBox.Image = Properties.Resources._01d;
                    break;
                case "01n":
                    currentPictureBox.Image = Properties.Resources._01n;
                    break;
                case "02d":
                    currentPictureBox.Image = Properties.Resources._02d;
                    break;
                case "02n":
                    currentPictureBox.Image = Properties.Resources._02n;
                    break;
                case "03d":
                    currentPictureBox.Image = Properties.Resources._03d;
                    break;
                case "03n":
                    currentPictureBox.Image = Properties.Resources._03n;
                    break;
                case "04d":
                    currentPictureBox.Image = Properties.Resources._04d;
                    break;
                case "04n":
                    currentPictureBox.Image = Properties.Resources._04n;
                    break;
                case "09d":
                    currentPictureBox.Image = Properties.Resources._09d;
                    break;
                case "09n":
                    currentPictureBox.Image = Properties.Resources._09n;
                    break;
                case "10d":
                    currentPictureBox.Image = Properties.Resources._10d;
                    break;
                case "10n":
                    currentPictureBox.Image = Properties.Resources._10n;
                    break;
                case "11d":
                    currentPictureBox.Image = Properties.Resources._11d;
                    break;
                case "11n":
                    currentPictureBox.Image = Properties.Resources._11n;
                    break;
                case "13d":
                    currentPictureBox.Image = Properties.Resources._13d;
                    break;
                case "13n":
                    currentPictureBox.Image = Properties.Resources._13n;
                    break;
                case "50d":
                    currentPictureBox.Image = Properties.Resources._50d;
                    break;
                case "50n":
                    currentPictureBox.Image = Properties.Resources._50n;
                    break;
            }
        }

        private void forecastLabel_Click(object sender, EventArgs e)
        {
            Form f = this.FindForm();
            f.Controls.Remove(this);

            ForecastScreen fs = new ForecastScreen();
            f.Controls.Add(fs);
        }

        private void CurrentScreen_Load(object sender, EventArgs e)
        {
            
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            try
            {
                string newLocation = locationInput.Text;
                Form1.ExtractForecast(newLocation);
                Form1.ExtractCurrent(newLocation);
                DisplayCurrent();
            }
            catch
            {
                locationInput.Text = "Location not found";
            }
        }
    }
}
