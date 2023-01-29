using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using nzwalks.models.domain;
using nzwalks.Repositories;

namespace nzwalks.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegionsController : Controller
    {
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionsController(IRegionRepository regionRepository,IMapper mapper)
        {
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }
        [HttpGet]
       public async Task<IActionResult> GetAllRegions()
        {
            var regions = await regionRepository.GetAllAsync();
            var regionsDTO = mapper.Map<List<models.DTOS.RegionsDTO>>(regions);
            return Ok(regionsDTO);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetRegionAsync")]
        public async Task <IActionResult> GetRegionAsync(Guid id)
        {
            var region = await regionRepository.GetRegion(id);
            if (region == null)
            {
                return NotFound();
            }
            var regionsDTO = mapper.Map<models.DTOS.RegionsDTO>(region);
            return Ok(regionsDTO);
        }

        [HttpPost]
        public async Task<IActionResult> AddRegionsAsync(models.DTOS.AddRegionRequestDTO requestdto)
        {
            var region = new Region()
            {
                Code = requestdto.Code,
                Name = requestdto.Name,
                lat = requestdto.lat,
                lon = requestdto.lon,
                Population = requestdto.Population,
                Area = requestdto.Area,
            };
            var response = await regionRepository.AddRegionAsync(region);
            var regionDTO = mapper.Map<models.DTOS.RegionsDTO>(response);
            return CreatedAtAction(nameof(GetRegionAsync), new { id = regionDTO.Id }, regionDTO);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteRegionAsync(Guid id)
        {
            var region = await regionRepository.deleteRegionAsync(id);
            if (region == null)
            {
                return NotFound();
            }
            var regionDTO = mapper.Map<models.DTOS.RegionsDTO>(region);
            return Ok(regionDTO);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> updateRegionAsync([FromRoute]Guid id, [FromBody]models.DTOS.AddRegionRequestDTO updateregion)
        {
            var region = new models.domain.Region()
            {
                Code = updateregion.Code,
                Name = updateregion.Name,
                lat = updateregion.lat,
                lon = updateregion.lon,
                Population = updateregion.Population,
                Area = updateregion.Area,
            };
            region = await regionRepository.updateRegionAsync(id, region);
            if (region == null)
            {
                return NotFound();
            }
            var uregion = mapper.Map<models.DTOS.RegionsDTO>(region);
            return Ok(uregion);
        }


    }
}
