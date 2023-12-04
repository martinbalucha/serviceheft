using Microsoft.AspNetCore.Mvc;
using ServiceHeft.Maintenance.Contracts.Automotive;
using ServiceHeft.Maintenance.Contracts.Automotive.Dtos;

namespace ServiceHeft.Webservice.CarMaintenance;

[ApiController]
[Route("api/[controller]")]
public class CarController : ControllerBase
{
    private readonly ICarService _carService;

    public CarController(ICarService carService)
    {
        _carService = carService ?? throw new ArgumentNullException(nameof(_carService)); 
    }


    [HttpPost]
    public async Task<IActionResult> CreateCar(CreateCarRequest request)
    {
        var result = await _carService.CreateAsync(request);
        
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteCar(DeleteCarRequest request)
    {
        await _carService.DeleteAsync(request);

        return Ok();
    }

    [HttpPut]
    public Task<IActionResult> UpdateCar()
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    public Task<IActionResult> GetCar(Guid carId)
    {
        throw new NotImplementedException();
    }
}
