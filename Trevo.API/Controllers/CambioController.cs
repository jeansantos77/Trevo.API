using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Trevo.API.Application.Interfaces;
using Trevo.API.Application.Models;

namespace Trevo.API.Controllers
{
    [Authorize(Roles = "Administrador")]
    [ApiController]
    [Route("api/[controller]")]
    public class CambioController : ControllerBase
    {
        private readonly ILogger<PaisController> _logger;
        private readonly ICambioService _service;

        public CambioController(ILogger<PaisController> logger, ICambioService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAll());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            try
            {
                return Ok(await _service.GetById(id));
            }
            catch (Exception ex)
            {
                return NotFound((ex.InnerException != null) ? ex.InnerException.Message : ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CambioModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                await _service.Add(model);
            }
            catch (Exception ex)
            {
                return NotFound((ex.InnerException != null) ? ex.InnerException.Message : ex.Message);
            }

            return StatusCode(StatusCodes.Status201Created, model);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CambioModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                await _service.Update(id, model);
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
                await _service.Delete(id);
            }
            catch (Exception ex)
            {
                return NotFound((ex.InnerException != null) ? ex.InnerException.Message : ex.Message);
            }

            return Ok();
        }

    }
}
