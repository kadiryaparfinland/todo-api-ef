using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDo.Application.IService;
using ToDo.Domain.Enum;
using ToDo.Domain.Model;

namespace ToDo.Api.Controllers
{
    [Authorize]
    public class ToDoController : BaseController
    {
        private readonly ITODOService _toDoService;

        public ToDoController(ITODOService toDoService)
        {
            _toDoService = toDoService;
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Add([FromBody] TODOModel toDoModel)
        {
            await _toDoService.Add(toDoModel);
            return Ok();
        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll([FromQuery] int? toDostatus)
        {
            var result = await _toDoService.GetAll(toDostatus);
            return Ok(result);
        }
        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var result = await _toDoService.GetById(id);
            return Ok(result);
        }

        [HttpPatch]
        [Route("Update")]
        public async Task<IActionResult> Update([FromBody] TODOModel toDoModel)
        {
            await _toDoService.Update(toDoModel);
            return Ok();
        }
        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            await _toDoService.Delete(id);
            return Ok();
        }
    }
}
