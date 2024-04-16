using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Trevo.API.Application.Interfaces;
using Trevo.API.Domain.Models;

namespace Trevo.API.Controllers
{
    [Authorize(Roles = "Administrador")]
    [ApiController]
    [Route("api/[controller]")]
    public class VeiculoController : ControllerBase
    {
        private readonly ILogger<VeiculoController> _logger;
        private readonly IVeiculoService _veiculoService;

        public VeiculoController(ILogger<VeiculoController> logger, IVeiculoService veiculoService)
        {
            _logger = logger;
            _veiculoService = veiculoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _veiculoService.GetAll());
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            try
            {
                return Ok(await _veiculoService.GetById(id));
            }
            catch (Exception ex)
            {
                return NotFound((ex.InnerException != null) ? ex.InnerException.Message : ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] VeiculoModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                await _veiculoService.Add(model);
            }
            catch (Exception ex)
            {
                return NotFound((ex.InnerException != null) ? ex.InnerException.Message : ex.Message);
            }

            return StatusCode(StatusCodes.Status201Created, model);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] VeiculoModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                await _veiculoService.Update(id, model);
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
                await _veiculoService.Delete(id);
            }
            catch (Exception ex)
            {
                return NotFound((ex.InnerException != null) ? ex.InnerException.Message : ex.Message);
            }

            return Ok();
        }

    }
}
