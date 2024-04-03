using Microsoft.AspNetCore.Mvc;
using milanesapp.IBusinessLogic;
using milanesapp.WebApi.Dtos;

namespace milanesapp.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class MilanesaController : ControllerBase
{

    private IMilanesaService _milanesaService;

    public MilanesaController(IMilanesaService milanesaService)
    {
        _milanesaService = milanesaService;
    }

    [HttpGet]
    public IActionResult GetMilanesas()
    {
        return Ok(_milanesaService.GetMilanesas().Select(c => new MilanesaDTO(c)).ToList());
    }

    [HttpGet("{id}")]
    public IActionResult GetGetMilanesaById([FromRoute] int id)
    {
        MilanesaDTO milanesaResponseModel = new MilanesaDTO(_milanesaService.GetMilanesaById(id));
        return Ok(milanesaResponseModel);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteGetMilanesasById([FromRoute] int id)
    {
        _milanesaService.DeleteMilanesa(id);
        return Ok();
    }

    [HttpPost]
    public IActionResult InsertMilanesa([FromBody] MilanesappCreateModel newMilanesa)
    {
        _milanesaService.InsertMilanesa(newMilanesa.ToEntity());
        return Ok();
    }

}
