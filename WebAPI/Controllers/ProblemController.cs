using Business.Abstract;
using Core.Extensions;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProblemController : ControllerBase
    {
        private IProblemService _problemService;

        public ProblemController(IProblemService problemService)
        {
            _problemService = problemService;
        }

        [HttpGet("getallproblems")]
        public IActionResult GetAll()
        {
            return this.ResponseResult(_problemService.GetAll());
        }
        [HttpGet("getallbytrackid")]
        public IActionResult GetAllByTrackId(int trackId)
        {
            return this.ResponseResult(_problemService.GetAllByTrackId(trackId));
        }

        [HttpGet("getallbytrackname")]
        public IActionResult GetAllByTrackName(string trackName)
        {
            return this.ResponseResult(_problemService.GetAllByTrackName(trackName));
        }

        [HttpGet("getallbytracknamewithdetails")]
        public IActionResult GetAllByTrackNameWithDetails(string trackName)
        {
            return this.ResponseResult(_problemService.GetAllByTrackNameWithDetails(trackName));
        }


        [HttpGet("getproblembyid")]
        public IActionResult GetById(int id)
        {
            return this.ResponseResult(_problemService.Get(x=>x.Id==id));
        }

        [HttpPost("addproblems")]
        public IActionResult Add(Problem problem)
        {
            return this.ResponseResult(_problemService.Add(problem));
        }

    }
}
