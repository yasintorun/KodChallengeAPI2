using Business.Abstract;
using Core.Extensions;
using Entities.Concrete;
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

        [HttpPost("addproblems")]
        public IActionResult Add(Problem problem)
        {
            return this.ResponseResult(_problemService.Add(problem));
        }

    }
}
