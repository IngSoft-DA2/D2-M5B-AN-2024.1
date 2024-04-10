using Microsoft.AspNetCore.Mvc;
using starwars.Domain;
using starwars.IBusinessLogic;
using starwars.WebApi.Dtos;
using System.Collections.Generic;
using starwars.Exceptions.BusinessLogicExceptions;
using starwars.WebApi.Filters;

namespace starwars.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PromotionController : ControllerBase
    {
        private IPromotionService _promotion;

        public PromotionController(IPromotionService promotion)
        {
            _promotion = promotion;
        }

        [HttpGet]
        public IActionResult GetAllPromotions()
        {
            return Ok(_promotion.GetAllPromotions());
        }
    }
}

