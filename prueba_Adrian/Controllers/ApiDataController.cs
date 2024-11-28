using Microsoft.AspNetCore.Mvc;
using prueba_Adrian.Models;
using prueba_Adrian.Repository;
using prueba_Adrian.Services;

namespace prueba_Adrian.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApiDataController : ControllerBase
    {
        private readonly ApiRepository _repository;
        private readonly ApiService _service;

        public ApiDataController(ApiRepository repository, ApiService service)
        {
            _repository = repository;
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<DataBank>>> GetData()
        {
            return Ok(await _repository.GetData());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DataBank>> GetDataById(int id)
        {
            var data = await _repository.GetDataById(id);
            if (data == null) return NotFound();
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> AddData([FromBody] DataBank data)
        {
            await _repository.AddData(data);
            return CreatedAtAction(nameof(GetDataById), new { id = data.Id }, data);
        }

        [HttpGet]
        [Route("GetInsertData")]
        public async Task<IActionResult> GetInsertData()
        {
           var data = await _service.FetchApiDataAsync();
            if(!await _repository.ExistInfo())
            {
                await _repository.AddDataList(data);
            }
            return Ok(data);
        }
    }
}
