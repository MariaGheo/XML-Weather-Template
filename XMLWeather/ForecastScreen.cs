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
    public partial class ForecastScreen : UserControl
    {
        public ForecastScreen()
        {
            InitializeComponent();
            displayForecast();
        }

        public void displayForecast()
        {
            Label[][] labelArrays =
            {
                new Label[] { date1Output, max1Output, min1Output },
                new Label[] { date2Output, max2Output, min2Output },
                new Label[] { date3Output, max3Output, min3Output },
                new Label[] { date4Output, max4Output, min4Output },
                new Label[] { date5Output, max5Output, min5Output },
                new Label[] { date6Output, max6Output, min6Output },
                new Label[] { date7Output, max7Output, min7Output },
            };

            PictureBox[] pictureBoxes =
            {
                conditionsPictureBox1, conditionsPictureBox2, conditionsPictureBox3, conditionsPictureBox4, conditionsPictureBox5, conditionsPictureBox6, conditionsPictureBox7
            };

            for (int i = 0; i < 7; i++)
            {
                labelArrays[i][0].Text = Form1.days[i].date;
                labelArrays[i][1].Text = Form1.days[i].tempHigh + "°C";
                labelArrays[i][2].Text = Form1.days[i].tempLow + "°C";
                
                switch (Form1.days[i].icon)
                {
                    case "01d":
                        pictureBoxes[i].Image = Properties.Resources._01d;
                        break;
                    case "01n":
                        pictureBoxes[i].Image = Properties.Resources._01n;
                        break;
                    case "02d":
                        pictureBoxes[i].Image = Properties.Resources._02d;
                        break;
                    case "02n":
                        pictureBoxes[i].Image = Properties.Resources._02n;
                        break;
                    case "03d":
                        pictureBoxes[i].Image = Properties.Resources._03d;
                        break;
                    case "03n":
                        pictureBoxes[i].Image = Properties.Resources._03n;
                        break;
                    case "04d":
                        pictureBoxes[i].Image = Properties.Resources._04d;
                        break;
                    case "04n":
                        pictureBoxes[i].Image = Properties.Resources._04n;
                        break;
                    case "09d":
                        pictureBoxes[i].Image = Properties.Resources._09d;
                        break;
                    case "09n":
                        pictureBoxes[i].Image = Properties.Resources._09n;
                        break;
                    case "10d":
                        pictureBoxes[i].Image = Properties.Resources._10d;
                        break;
                    case "10n":
                        pictureBoxes[i].Image = Properties.Resources._10n;
                        break;
                    case "11d":
                        pictureBoxes[i].Image = Properties.Resources._11d;
                        break;
                    case "11n":
                        pictureBoxes[i].Image = Properties.Resources._11n;
                        break;
                    case "13d":
                        pictureBoxes[i].Image = Properties.Resources._13d;
                        break;
                    case "13n":
                        pictureBoxes[i].Image = Properties.Resources._13n;
                        break;
                    case "50d":
                        pictureBoxes[i].Image = Properties.Resources._50d;
                        break;
                    case "50n":
                        pictureBoxes[i].Image = Properties.Resources._50n;
                        break;
                }
            }

            int temp = Convert.ToInt32(Form1.days[1].tempHigh);

            if (temp > 25)
            {
                BackColor = Color.FromArgb(50, 10, 10);
            }
            else if (temp > 15)
            {
                BackColor = Color.FromArgb(10, 10, 10);
            }
            else if (temp > 0)
            {
                BackColor = Color.FromArgb(10, 10, 17);
            }
            else
            {
                BackColor = Color.FromArgb(10, 10, 23);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Form f = this.FindForm();
            f.Controls.Remove(this);

            CurrentScreen cs = new CurrentScreen();
            f.Controls.Add(cs);
        }

        private void ForecastScreen_Load(object sender, EventArgs e)
        {
            
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            try
            {
                string newLocation = locationInput.Text;
                Form1.ExtractForecast(newLocation);
                Form1.ExtractCurrent(newLocation);
                displayForecast();

                Form1.location = newLocation;
            }
            catch
            {
                locationInput.Text = "Location not found";
                string newLocation = locationInput.Text;
                Form1.ExtractForecast(Form1.location);
                Form1.ExtractCurrent(Form1.location);
                displayForecast();
            }
        }
    }
}
