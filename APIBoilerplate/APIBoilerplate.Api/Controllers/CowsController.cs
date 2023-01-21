using APIBoilerplate.Contracts.Cows;

using MapsterMapper;

using Microsoft.AspNetCore.Mvc;

namespace APIBoilerplate.Api.Controllers
{
    [Route("farms/{farmId}/cows")]
    public class CowsController : ApiController
    {
        //private readonly ICowService _cowService;
        private readonly IMapper _mapper;

        public CowsController(IMapper mapper)
        {
            //_cowService = cowService;
            _mapper = mapper;
        }

        // [HttpGet]
        // public async Task<IActionResult> Get()
        // {
        //     var cows = await _cowService.GetCowsAsync();
        //     var response = _mapper.Map<IEnumerable<CowResponse>>(cows);
        //     return Ok(response);
        // }

        // [HttpGet("{id}")]
        // public async Task<IActionResult> Get(string id)
        // {
        //     var cow = await _cowService.GetCowAsync(id);
        //     var response = _mapper.Map<CowResponse>(cow);
        //     return Ok(response);
        // }

        [HttpPost]
        public IActionResult Post(
            [FromBody] CreateCowOnboardingRequest request,
            [FromRoute] string farmId)
        {
            // var cow = _mapper.Map<Cow>(request);
            // await _cowService.CreateCowAsync(cow);
            // var response = _mapper.Map<CowResponse>(cow);
            return  Ok(request);
        }

        // [HttpPut("{id}")]
        // public async Task<IActionResult> Put(string id, [FromBody] UpdateCowRequest request)
        // {
        //     var cow = await _cowService.GetCowAsync(id);
        //     _mapper.Map(request, cow);
        //     await _cowService.UpdateCowAsync(cow);
        //     var response = _mapper.Map<CowResponse>(cow);
        //     return Ok(response);
        // }

        // [HttpDelete("{id}")]
        // public async Task<IActionResult> Delete(string id)
        // {
        //     await _cowService.DeleteCowAsync(id);
        //     return Ok();
        // }
    }
}