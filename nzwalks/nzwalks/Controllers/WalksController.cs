using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using nzwalks.models.domain;
using nzwalks.Repositories;

namespace nzwalks.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WalksController : Controller
    {
        private readonly IWalksRepository walksRepository;
        private readonly IMapper mapper;

        public WalksController(IWalksRepository walksRepository,IMapper mapper)
        {
            this.walksRepository = walksRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult>GetAllWalksAsync()
        {
            var walk = await walksRepository.GetAllWalksAsync();
            var walkDTO = mapper.Map<List<models.DTOS.WalksDTO>>(walk);
            return Ok(walkDTO);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetRegionByIdAsync")]
        public async Task<IActionResult> GetRegionByIdAsync(Guid id)
        {
            var walk = await walksRepository.GetWalkBYIdAsync(id);
            var walkDTO = mapper.Map<models.DTOS.WalksDTO>(walk);
            return Ok(walkDTO);
        }

        [HttpPost]
        public async Task<IActionResult> AddWalkAsync([FromBody] models.DTOS.AddWalkRequestDTO walk)
        {
            var dwalk = mapper.Map<models.domain.walks>(walk);
            dwalk = await walksRepository.AddWalkAsync(dwalk);
            var walkDTO = mapper.Map<models.DTOS.WalksDTO>(dwalk);
            return CreatedAtAction(nameof(GetRegionByIdAsync), new { id = walkDTO.Id }, walkDTO);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult>updateWalkAsync([FromRoute] Guid id,[FromBody] models.DTOS.AddWalkRequestDTO walk)
        {
            var dwalk = mapper.Map<models.domain.walks>(walk);
            dwalk = await walksRepository.UpdateWalkAsync(id, dwalk);
            if (dwalk == null)
            {
                return NotFound();
            }
            var walkDTO = mapper.Map<models.DTOS.WalksDTO>(dwalk);
            return Ok(walkDTO);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult>deleteWalkAsync(Guid id)
        {
            var dwalk = await walksRepository.deleteWalkAsync(id);
            if(dwalk == null)
            {
                return NotFound();
            }
            var walkDTO = mapper.Map<models.DTOS.WalksDTO> (dwalk);
            return Ok(walkDTO);
        }
    }
}
