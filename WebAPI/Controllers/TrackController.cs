using Business.Abstract;
using Core.Extensions;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrackController : ControllerBase
    {
        private ITrackService _trackService;

        public TrackController(ITrackService trackService)
        {
            _trackService = trackService;
        }

        [HttpGet("getalltracks")]
        public IActionResult GetAll()
        {
            return this.ResponseResult(_trackService.GetAll());
        }

        [HttpPost("addtrack")]
        public IActionResult Add(Track track)
        {
            return this.ResponseResult(_trackService.Add(track));
        }

        [HttpPut("updatetrack")]
        public IActionResult Update(Track track)
        {
            return this.ResponseResult(_trackService.Update(track));
        }
    }
}
