using Microsoft.AspNetCore.Mvc;
using Logic;
using Logic.Models;
using WebAPI.Filters;

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
    [ValidationFilter]
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
    [ValidationFilter]
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