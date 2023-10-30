using Microsoft.AspNetCore.Mvc;

namespace ServiceHeft.Webservice;

[ApiController]
[Route("api/[controller]")]
public class CarController : ControllerBase
{

    [HttpPost]
    public Task<IActionResult> CreateCar()
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
    public Task<IActionResult> GetCar() 
    { 
        throw new NotImplementedException(); 
    }
}
