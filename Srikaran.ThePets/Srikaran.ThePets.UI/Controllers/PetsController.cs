using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Srikaran.ThePets.Services.QueriesService;

namespace Srikaran.ThePets.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Pets")]
    public class PetsController : Controller
    {
        private readonly IQueriesService queriesService;

        public PetsController(IQueriesService _queriesService)
        {
            queriesService = _queriesService;
        }

        // GET api/values - Search by pet type
        [HttpGet("{type}")]
        public async Task<IActionResult> Get(string type)
        {
            try
            {
                if (String.IsNullOrEmpty(type))
                {
                    return BadRequest();
                }

                var pets = await queriesService.GetPetsByTypeAsync(type);
                return Ok(pets);
            }
            catch (Exception ex)
            {
                // _logger.LogError($"Some error in the GetAllOwners method: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}