
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class PlatformsController : ControllerBase
{
    private readonly IPlatformRepo _platformsRepo;
    private readonly IMapper _autoMapper;

    private readonly ICmdServiceHttpClient _cmdSvcHttpClient;

    public PlatformsController(
        IPlatformRepo platformsRepo,
        IMapper autoMapper,
        ICmdServiceHttpClient cmdServiceHttpClient
        )
    {
        _platformsRepo = platformsRepo;
        _autoMapper = autoMapper;
        _cmdSvcHttpClient = cmdServiceHttpClient;
    }

    [HttpGet]
    public IActionResult GetPlatforms()
    {
        var platforms = _platformsRepo.GetAllPlatforms();
        return Ok(_autoMapper.Map<IEnumerable<PlatformReadDto>>(platforms));
    }

    [HttpGet("{guid}", Name="GetPlatformById")]
    public IActionResult GetPlatformById(Guid guid)
    {
        var platform = _platformsRepo.GetPlatformById(guid);
        if(platform == null)
            return NotFound($"Platform with Id - {guid} Not Found!");

        return Ok(_autoMapper.Map<PlatformReadDto>(platform));
    }

    [HttpPost]
    [Route("create")]
    public IActionResult CreatePlatform([FromBody]PlatformCreateDto newPlatformDto)
    {
        if(newPlatformDto == null)
            return BadRequest("New Platform cannot be null");

        var newPlatformModel =_autoMapper.Map<Platform>(newPlatformDto);
        _platformsRepo.CreatePlatform(newPlatformModel);
        _platformsRepo.SaveChanges();

        var platformReadDto = _autoMapper.Map<PlatformReadDto>(newPlatformModel);
        _cmdSvcHttpClient.SendNewPlatformAsync(platformReadDto);
        return CreatedAtRoute(nameof(GetPlatformById), new {guid = platformReadDto.Id}, platformReadDto);
    }
}