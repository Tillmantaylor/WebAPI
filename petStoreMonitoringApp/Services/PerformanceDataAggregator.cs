﻿using petStoreMonitoringApp.Models;
using petStoreMonitoringApp.Models.ViewModels;
using System.Text.Json;

namespace petStoreMonitoringApp.Services
{
    public static class PerformanceDataAggregator
    {
        private const string BASE_ADDRESS = "https://se2monitoringwebapi.azurewebsites.net";

        private static readonly HttpClient client = new HttpClient();
        private static JsonSerializerOptions options
            = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        static PerformanceDataAggregator()
        {
            client.BaseAddress = new Uri(BASE_ADDRESS);
        }

        public static async Task<PerformanceMetricsVM> GetDataFromAPI()
        {
            var performanceMetricsVM = new PerformanceMetricsVM();

            HttpResponseMessage response = await client.GetAsync("/api/Sessions");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            performanceMetricsVM.SessionsList = JsonSerializer.Deserialize<List<Session>>(responseBody, options);

            return performanceMetricsVM;
        }

        public static PerformanceMetricsVM AggregateData(PerformanceMetricsVM performanceMetricsVM)
        {
            return performanceMetricsVM;
        }
    }
}
