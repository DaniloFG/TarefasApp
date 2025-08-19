using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TarefasApp.Application.Commands;
using TarefasApp.Application.Dtos;
using TarefasApp.Application.Interfaces;

namespace TarefasApp.API.Controller
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TarefasController : ControllerBase
    {
        private readonly ITarefaAppService _service;

        public TarefasController(ITarefaAppService service)
        {
            _service = service;
        }

        /// <summary>
        /// Realiza o post
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(TarefaDto), 201)]
        public async Task<IActionResult> Post(TarefaCreateCommand command)
        {
            var dto = await _service.Create(command);
            return StatusCode(201, dto);
        }

        /// <summary>
        /// Realiza Put
        /// </summary>
        [HttpPut]
        [ProducesResponseType(typeof(TarefaDto), 200)]
        public async Task<IActionResult> Put(TarefaUpdateCommand command)
        {
            var dto = await _service.Update(command);
            return StatusCode(200, dto);
        }

        /// <summary>
        /// Realiza Delete
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(TarefaDto), 200)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new TarefaDeleteCommand { Id = id };
            var dto = await _service.Delete(command);

            return StatusCode(200, dto);
        }

        /// <summary>
        /// Realiza GetAll
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(List<TarefaDto>), 200)]
        public async Task<IActionResult> GetAll()
        {
            var dtos = await _service.GetAll();
            return StatusCode(200, dtos);
        }

        /// <summary>
        /// Realiza GetById
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(TarefaDto), 200)]
        public async Task<IActionResult> GetById(Guid id)
        {
            var dto = await _service.GetById(id);
            return Ok(dto);
        }
    }
}