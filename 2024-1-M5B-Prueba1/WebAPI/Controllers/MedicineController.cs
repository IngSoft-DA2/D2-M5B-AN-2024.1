using Microsoft.AspNetCore.Mvc;
using Logic;
using Logic.Models;

namespace WebAPI.Controllers;

[ApiController]
[ResultObjectFilter]
[Route("[controller]")]
public class MedicineController : ControllerBase
{
    private readonly IMedicineService service;
    public MedicineController(IMedicineService service)
    {
        this.service = service;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
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
    public IActionResult MainDrug([FromBody] Medicine body)
    {
        try
        {
            return Ok(this.service.GetMainDrug(body));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}