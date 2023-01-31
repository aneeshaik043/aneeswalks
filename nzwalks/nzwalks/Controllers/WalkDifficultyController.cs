using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using nzwalks.models.domain;
using nzwalks.Repositories;

namespace nzwalks.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WalkDifficultyController : Controller
    {
        private readonly IwalksdifficultyRepository walksdifficulty;
        private readonly IMapper mapper;

        public WalkDifficultyController(IwalksdifficultyRepository walksdifficulty, IMapper mapper)
        {
            this.walksdifficulty = walksdifficulty;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult>GetAllAsync()
        {
            var domain = await walksdifficulty.GetAllAsync();
            var DTO = mapper.Map<List<models.DTOS.WalksDifficultyDTO>>(domain);
            return Ok(DTO);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetAsync")]
        public async Task<IActionResult>GetAsync(Guid id)
        {
            var domain = await walksdifficulty.GetAsync(id);
            if (domain == null)
            {
                return NotFound();
            }
            var DTO = mapper.Map<models.DTOS.WalksDifficultyDTO>(domain);
            return Ok(DTO);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody]models.DTOS.WalkDifficultyAddRequestDTO wdar)
        {
            var domain = mapper.Map<models.domain.walksdifficulty>(wdar);
            domain = await walksdifficulty.AddAsync(domain);
            var DTO = mapper.Map<models.DTOS.WalksDifficultyDTO>(domain);
            return CreatedAtAction(nameof(GetAsync), new { id = DTO.Id }, DTO);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var dwd = await walksdifficulty.DeleteAsync(id);
            if (dwd == null)
            {
                return NotFound();
            }
            var DTO = mapper.Map<models.DTOS.WalksDifficultyDTO>(dwd);
            return Ok(DTO);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody]models.DTOS.WalkDifficultyAddRequestDTO wdar)
        {
            var domain = mapper.Map<models.domain.walksdifficulty>(wdar);
            domain = await walksdifficulty.UpdateAsync(id,domain);
            if (domain == null)
            {
                return NotFound();
            }
            var DTO = mapper.Map<models.DTOS.WalksDifficultyDTO>(domain);
            return Ok(DTO);
        }



    }
}
