using Core.Utilities.Results;
using Microsoft.AspNetCore.Mvc;

namespace Core.Extensions
{
    public static class ControllerExtension
    {
        public static IActionResult ResponseResult(this ControllerBase controller, IResult result)
        {
            if (result.Success)
            {
                return controller.Ok(result);
            }
            return controller.BadRequest(result);
        }
    }
}