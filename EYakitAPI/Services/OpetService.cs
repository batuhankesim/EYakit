using System.Text.Json;
using EYakitAPI.Model;

namespace EYakitAPI.Services;

public class OpetService
{
    private readonly HttpClient _httpClient;

    public OpetService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Fuel>> GetFuelPricesAsync(int provinceCode)
    {
        var url = $"https://api.opet.com.tr/api/fuelprices/prices?ProvinceCode={provinceCode}&IncludeAllProducts=true";
        var response = await _httpClient.GetAsync(url);
        
        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            var fuelPrices = JsonSerializer.Deserialize<List<Fuel>>(json);

            return fuelPrices;
        }

        return new List<Fuel>();

    }
}