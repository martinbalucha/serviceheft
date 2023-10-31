using Microsoft.AspNetCore.Mvc;
using ServiceHeft.Webservice.CarMaintenance.Requests;

namespace ServiceHeft.Webservice.CarMaintenance;

[ApiController]
[Route("api/[controller]")]
public class CarController : ControllerBase
{

    [HttpPost]
    public Task<IActionResult> CreateCar(CreateCarRequest request)
    {
        throw new NotImplementedException();
    }

    [HttpDelete]
    public Task<IActionResult> DeleteCar()
    {
        throw new NotImplementedException();
    }

    [HttpPut]
    public Task<IActionResult> UpdateCar()
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    public Task<IActionResult> GetCar(GetCarRequest request)
    {
        throw new NotImplementedException();
    }
}
