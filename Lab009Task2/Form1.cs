using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab009Task2
{
    public partial class Form1 : Form
    {
        static string[] lat;
        static string[] lon;
        public Form1()
        {
            InitializeComponent();
            string[] cities = File.ReadAllLines(@"C:\Users\anyap\source\repos\Lab009\city.txt");
            lat = new string[cities.Length];
            lon = new string[cities.Length];
            string[] nameOfCities = new string[cities.Length];
            for (int i = 0; i < cities.Length; i++)
            {
                nameOfCities[i] = cities[i].Substring(0, cities[i].IndexOf("\t"));
                lat[i] = cities[i].Substring(cities[i].IndexOf("\t") + 1,
                  cities[i].IndexOf(",") - cities[i].IndexOf("\t") - 1);
                lon[i] = cities[i].Substring(cities[i].IndexOf(",") + 2);
            }
            ListOfCities.Items.AddRange(nameOfCities);
        }

        private void ListOfCities_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        static readonly HttpClient client = new HttpClient();

        static async Task GetAsinc(string selectedCity, int resultIndex)
        {
            try
            {
                string s1 = "https://api.openweathermap.org/data/2.5/weather?lat=";
                string s2 = "&lon=";
                string s3 = "&appid=a764d78375cef095ddfb384cfd507ddb";
                string url = s1 + lat[resultIndex].Replace(".", ",") + s2 + lon[resultIndex].Replace(".", ",") + s3;
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string content = await response.Content.ReadAsStringAsync();

                string temp0;
                string temp;
                temp0 = content.Substring(content.IndexOf("temp") + 6);
                temp = temp0.Substring(0, temp0.IndexOf(","));


                string description0;
                string description;
                description0 = content.Substring(content.IndexOf("description") + 14);
                description = description0.Substring(0, description0.IndexOf("\""));

                Thread.Sleep(5000);
                MessageBox.Show("Температура: " + temp + " К; " +
                    "Описание погоды: " + description, selectedCity);
            }
            catch (HttpRequestException)
            {
                MessageBox.Show("\nException Caught!");
            }

        }
        private async void ShowWeather_Click(object sender, EventArgs e)
        {
            if (ListOfCities.SelectedItem != null)
            {
                string selectedCity = (string)ListOfCities.SelectedItem;
                int resultIndex = ListOfCities.FindStringExact(selectedCity);
                await Task.Run(() => GetAsinc(selectedCity,resultIndex));

            }
            else
            {
                MessageBox.Show("Сначала выберите город из списка");
            }
        }
    }
}
