using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Trevo.API.Application.Interfaces;
using Trevo.API.Application.Models;

namespace Trevo.API.Controllers
{
    [Authorize(Roles = "Administrador")]
    [ApiController]
    [Route("api/[controller]")]
    public class CidadeController : ControllerBase
    {
        private readonly ILogger<CidadeController> _logger;
        private readonly ICidadeService _cidadeService;

        public CidadeController(ILogger<CidadeController> logger, ICidadeService cidadeService)
        {
            _logger = logger;
            _cidadeService = cidadeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _cidadeService.GetAll());
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            try
            {
                return Ok(await _cidadeService.GetById(id));
            }
            catch (Exception ex)
            {
                return NotFound((ex.InnerException != null) ? ex.InnerException.Message : ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CidadeModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                await _cidadeService.Add(model);
            }
            catch (Exception ex)
            {
                return NotFound((ex.InnerException != null) ? ex.InnerException.Message : ex.Message);
            }

            return StatusCode(StatusCodes.Status201Created, model);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CidadeModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                await _cidadeService.Update(id, model);
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
                await _cidadeService.Delete(id);
            }
            catch (Exception ex)
            {
                return NotFound((ex.InnerException != null) ? ex.InnerException.Message : ex.Message);
            }

            return Ok();
        }

    }
}
