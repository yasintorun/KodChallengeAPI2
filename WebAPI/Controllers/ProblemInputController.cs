using Business.Abstract;
using Core.Extensions;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProblemInputController : ControllerBase
    {
        private IProblemInputService _problemInputService;

        public ProblemInputController(IProblemInputService problemInputService)
        {
            _problemInputService = problemInputService;
        }

        [HttpGet("getprobleminputsbyproblemid")]
        public IActionResult GetBy(int problemId)
        {
            return this.ResponseResult(_problemInputService.GetByProblemId(problemId));
        }

        [HttpPost("addprobleminput")]
        public IActionResult Add(ProblemInput problemInput)
        {
            return this.ResponseResult(_problemInputService.Add(problemInput));
        }
    }
}
