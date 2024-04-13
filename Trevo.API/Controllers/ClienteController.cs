using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Trevo.API.Application.Interfaces;
using Trevo.API.Application.Models;

namespace Trevo.API.Controllers
{
    [Authorize(Roles = "Administrador")]
    [ApiController]
    [Route("api/[controller]")]
    public class FornecedorController : ControllerBase
    {
        private readonly ILogger<FornecedorController> _logger;
        private readonly IFornecedorService _fornecedorService;

        public FornecedorController(ILogger<FornecedorController> logger, IFornecedorService fornecedorService)
        {
            _logger = logger;
            _fornecedorService = fornecedorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _fornecedorService.GetAll());
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            try
            {
                return Ok(await _fornecedorService.GetById(id));
            }
            catch (Exception ex)
            {
                return NotFound((ex.InnerException != null) ? ex.InnerException.Message : ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] FornecedorModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                await _fornecedorService.Add(model);
            }
            catch (Exception ex)
            {
                return NotFound((ex.InnerException != null) ? ex.InnerException.Message : ex.Message);
            }

            return StatusCode(StatusCodes.Status201Created, model);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] FornecedorModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                await _fornecedorService.Update(id, model);
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
                await _fornecedorService.Delete(id);
            }
            catch (Exception ex)
            {
                return NotFound((ex.InnerException != null) ? ex.InnerException.Message : ex.Message);
            }

            return Ok();
        }

    }
}
