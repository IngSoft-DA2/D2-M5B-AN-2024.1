using Microsoft.AspNetCore.Mvc;
using Logic;
using Logic.Models;
using WebAPI.Filter;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class MedicineController : ControllerBase
{
    private readonly IMedicineService service;
    public MedicineController(IMedicineService service)
    {
        this.service = service;
    }

    [HttpGet]
    [ValidatorFilter("M5B-AN")]
    public IActionResult GetAll()
    {
        try
        {
            return Ok(new { success = true, response = this.service.GetAll() });
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("main-drug")]
    [ValidatorFilter("M5B-AN")]
    public IActionResult MainDrug([FromBody] Medicine body)
    {
        try
        {
            return Ok(new { success = true, response = this.service.GetMainDrug(body) });
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}