using Microsoft.AspNetCore.Mvc;

namespace TarefasApp.API.Controller
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TarefasController : ControllerBase
    {
        /// <summary>
        /// Realiza o post
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Post()
        {
            await Task.CompletedTask;
            return Ok();
        }

        /// <summary>
        /// Realiza Put
        /// </summary>
        [HttpPut]
        public async Task<IActionResult> Put()
        {
            await Task.CompletedTask;
            return Ok();
        }

        /// <summary>
        /// Realiza Delete
        /// </summary>
        [HttpDelete]
        public async Task<IActionResult> Delete()
        {
            await Task.CompletedTask;
            return Ok();
        }

        /// <summary>
        /// Realiza Get
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            await Task.CompletedTask;
            return Ok();
        }
    }
}