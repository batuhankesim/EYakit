using Microsoft.AspNetCore.Mvc;
using EYakitAPI.Services;
using EYakitAPI.Model;

namespace EYakitAPI.Conrollers;

[ApiController]
[Route("api/[controller]")]
public class OpetController : ControllerBase
{
    private readonly OpetService _opetService;

    public OpetController(OpetService opetService)
    {
        _opetService = opetService;
    }
    
    [HttpGet("{provinceCode}")]
    public async Task<ActionResult<List<Fuel>>> GetFuelPrices(int provinceCode)
    {
        var fuelPrices = await _opetService.GetFuelPricesAsync(provinceCode);
        if (fuelPrices.Count > 0)
        {
            return Ok(fuelPrices);
        }

        return BadRequest();
    }
    
}