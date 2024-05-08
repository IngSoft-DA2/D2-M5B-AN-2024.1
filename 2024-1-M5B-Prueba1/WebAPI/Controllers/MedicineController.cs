using Microsoft.AspNetCore.Mvc;
using Logic;
using Logic.Models;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/v1/medicinas")]
public class MedicineController : ControllerBase
{
    private readonly IMedicineService service;
    public MedicineController(IMedicineService service)
    {
        this.service = service;
    }

    [HttpGet]
    public IActionResult GetAll([FromHeader]string header)
    {
        if(header == null || header != "M5B-AN")
        {
            return Unauthorized();
        }
        try
        {
            return Ok(this.service.GetAll());
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("main-drug")]
    public IActionResult MainDrug([FromHeader]string header,[FromBody] Medicine body)
    {
        if(header != "M5B-AN")
        {
            return Unauthorized();
        }
        try
        {
            return SuccessResponse("operacion exitosa");
        }
        catch (Exception ex)
        {
            return ErrorResponse(ex);
        }
    }

    protected IActionResult SuccessResponse(string response)
    {
        return Ok(new { success = true , response });
    }

    protected IActionResult ErrorResponse(Exception ex)
    {
        return StatusCode(500, new { success = false, response = ex.Message });
    }
    
    
}