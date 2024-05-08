using Microsoft.AspNetCore.Mvc;
using Logic;
using Logic.Models;

namespace WebAPI.Controllers;

[Route("[controller]")]
[ApiController]
public class MedicineController : ControllerBase
{
    private readonly IMedicineService service;
    public MedicineController(IMedicineService service)
    {
        this.service = service;
    }

    [HttpGet]
    [RequestFilter]
    public IActionResult GetAll()
    {
        try
        {
            return Ok(new ResponseModel { Success = true, Response = this.service.GetAll() });
        }
        catch (Exception ex)
        {
            return BadRequest(new ResponseModel { Success = false, Response = ex.Message });
        }
    }

    [HttpPost("main-drug")]
    [RequestFilter]
    public IActionResult MainDrug([FromBody] Medicine body)
    {
        try
        {
            return Ok(new ResponseModel { Success = true, Response = this.service.GetMainDrug(body) });
        }
        catch (Exception ex)
        {
            return BadRequest(new ResponseModel { Success = false, Response = ex.Message });
        }
    }
}