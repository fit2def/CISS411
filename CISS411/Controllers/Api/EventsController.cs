using AutoMapper;
using CISS411.Models.DomainModels;
using CISS411.Models.Interfaces;
using CISS411.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CISS411.Controllers.Api
{
    [Route("api/events")]
    public class EventsController : Controller
    {
        private IModelRepository _repository;
        private ILogger<EventsController> _logger;

        public EventsController(IModelRepository repository, 
            ILogger<EventsController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet("")]
        public IActionResult GetEvents()
        {
            try
            {
                return Ok(
                    Mapper.Map<IEnumerable<EventViewModel>>(_repository.Events())
                );
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest("An error occurred.");
            }

        }

        //This is for admin consumption only.
        [HttpPost("")]
        public async Task<IActionResult> PostEvent([FromBody]EventViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var newEvent = Mapper.Map<Event>(vm);
                _repository.AddEvent(newEvent);

                if (await _repository.SaveChangesAsync())
                    return Created($"api/events/{newEvent.Name}",
                    Mapper.Map<EventViewModel>(newEvent));
            }
            return BadRequest("Failed to save the event.");
        }

    }
}
