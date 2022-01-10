using Business.Abstract;
using Business.DependencyResolvers.Ninject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Core.Extensions;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DifficultyController : ControllerBase
    {
        private IDifficultyService _difficultyService;

        public DifficultyController(IDifficultyService difficultyService)
        {
            _difficultyService = difficultyService;
        }

        [HttpGet("getalldifficulties")]
        public IActionResult GetAll()
        {
            return this.ResponseResult(_difficultyService.GetAll());
        }

    }
}
