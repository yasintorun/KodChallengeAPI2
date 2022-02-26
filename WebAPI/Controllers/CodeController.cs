using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Text;
using System;
using System.Diagnostics;
using Core.Extensions;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CodeController : ControllerBase
    {
        [HttpPost("resruncode")]
        public IActionResult ResRunCode(CodeDto codeDto)
        {
            //return Ok(codeDto);
            codeDto.Params = "";
            var uri = RunCode(codeDto);
            return Ok(uri);
        }

        [HttpPost("test")]
        public IActionResult Test()
        {
            return Ok("Başarılı");
        }
        
        string RunCode(CodeDto codeDto)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost/api/kodchallenge/");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            codeDto.Function_name = "sumTwoNumber";
            codeDto.Params = "1,2";
            var response = client.PostAsJsonAsync(
                "runcode.php", codeDto);
            return response.Result.Content.ReadAsStringAsync().Result;
        }
    }
}
