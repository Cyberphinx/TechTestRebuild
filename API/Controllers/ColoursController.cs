using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/colours")]
    [ApiController]
    public class ColoursController : ControllerBase
    {
        public ColoursController(IColourRepository colourRepository)
        {
            this.ColourRepository = colourRepository;
        }

        private IColourRepository ColourRepository { get; }

        [HttpGet]
        public IActionResult GetAll()
        {
            var colours =  this.ColourRepository.GetAll();

            return this.Ok(colours);
        }
    }
}