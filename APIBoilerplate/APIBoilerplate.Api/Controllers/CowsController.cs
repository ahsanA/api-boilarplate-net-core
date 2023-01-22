using System.Security.Claims;

using APIBoilerplate.Application.Cows.Commands.AddCow;
using APIBoilerplate.Contracts.Cows;

using MapsterMapper;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace APIBoilerplate.Api.Controllers
{
    [Route("farms/{farmId}/cows")]
    public class CowsController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly ISender _mediator;

        public CowsController(IMapper mapper, ISender mediator)
        {
            //_cowService = cowService;
            _mapper = mapper;
            _mediator = mediator;
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
        public async Task<IActionResult> Post(
            [FromBody] AddCowRequest request,
            [FromRoute] string farmId)
        {
            string addedBy = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            var command = _mapper.Map<AddCowCommand>((request, addedBy, farmId.Substring(1, 36)));
            var addCowResult = await _mediator.Send(command);
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