using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Trevo.API.Application.Interfaces;
using Trevo.API.Application.Models;

namespace Trevo.API.Controllers
{
    [Authorize(Roles = "Administrador")]
    [ApiController]
    [Route("api/[controller]")]
    public class PaisController : ControllerBase
    {
        private readonly ILogger<PaisController> _logger;
        private readonly IPaisService _paisService;

        public PaisController(ILogger<PaisController> logger, IPaisService paisService)
        {
            _logger = logger;
            _paisService = paisService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _paisService.GetAll());
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            try
            {
                return Ok(await _paisService.GetById(id));
            }
            catch (Exception ex)
            {
                return NotFound((ex.InnerException != null) ? ex.InnerException.Message : ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] PaisModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                await _paisService.Add(model);
            }
            catch (Exception ex)
            {
                return NotFound((ex.InnerException != null) ? ex.InnerException.Message : ex.Message);
            }

            return StatusCode(StatusCodes.Status201Created, model);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] PaisModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                await _paisService.Update(id, model);
            }
            catch (Exception ex)
            {
                return NotFound((ex.InnerException != null) ? ex.InnerException.Message : ex.Message);
            }

            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                await _paisService.Delete(id);
            }
            catch (Exception ex)
            {
                return NotFound((ex.InnerException != null) ? ex.InnerException.Message : ex.Message);
            }

            return Ok();
        }

    }
}
