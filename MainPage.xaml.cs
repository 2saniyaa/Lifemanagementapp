using Microsoft.Maui.Controls;
using System;
using System.Threading.Tasks;

namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {
        private readonly WeatherService _weatherService;

        public MainPage()
        {
            InitializeComponent();
            _weatherService = new WeatherService();
        }

        private async void OnFetchWeatherClicked(object sender, EventArgs e)
        {
            string city = CityInputField.Text;
            if (string.IsNullOrEmpty(city))
            {
                await DisplayAlert("Error", "Please enter a city.", "OK");
                return;
            }

            await FetchWeatherData(city);
        }

        private async void OnNavigateToTasksPage(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//TodoPage");
        }

        private async Task FetchWeatherData(string city)
        {
            try
            {
                var data = await _weatherService.GetWeatherByCityAsync(city);
                CurrentTempLabel.Text = $"Temperature: {data.main.temp}°C";
                MinTempLabel.Text = $"Min Temp: {data.main.temp_min}°C";
                MaxTempLabel.Text = $"Max Temp: {data.main.temp_max}°C";
                WeatherDescLabel.Text = $"Details: {data.weather[0].description}";

                WindStatusLabel.Text = data.wind.speed > 4
                    ? "Wind Status: Strong winds!"
                    : "Wind Status: Normal";
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }
}
