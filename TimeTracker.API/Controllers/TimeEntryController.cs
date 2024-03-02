using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeTracker.API.Services;
using TimeTracker.Domain.Dto.Request;
using TimeTracker.Domain.Dto.Response;
using TimeTracker.Domain.entities;

namespace TimeTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeEntryController : ControllerBase
    {
        private readonly ITimeEntryService _timeEntryService;
        public TimeEntryController(ITimeEntryService timeEntryService)
        {
            _timeEntryService = timeEntryService;
        }

        [HttpGet]
        public async Task<ActionResult<List<TimeEntryDTO>>> GetAllTimeEntries()
        {
            return Ok(await _timeEntryService.GetAllTimeEntries());
        }

        [HttpPost]
        public async Task<ActionResult<List<TimeEntryDTO>>> CreateTimeEntry(TimeEntryCreateRequest request)
        {
            return Ok(await _timeEntryService.CreateTimeEntry(request));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<TimeEntryDTO>>> UpdateTimeEntry(int id, TimeEntryUpdateRequest request)
        {
            var result = await _timeEntryService.UpdateTimeEntry(id, request);
            if (result != null)
            {
                NotFound();
            }
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TimeEntryDTO>> GetTimeEntry(int id)
        {
            var result = await _timeEntryService.GetTimeEntry(id);
            if(result == null)
            {
                NotFound();
            }
            return Ok(result);  
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<TimeEntryDTO>>> DeleteTimeEntry(int id)
        {
            var result = await _timeEntryService.DeleteTimeEntry(id);
            if (result == null)
            {
                NotFound();
            }
            return Ok(result);
        }
    }
}
