using AutoGestor360Servidor.Models;
using Microsoft.AspNetCore.Mvc;
using Servidor.Services;

namespace AutoGestor360Servidor.Controllers;

[ApiController]
[Route("[controller]")]
public class RegisterController(IRegisterService registerService) : ControllerBase
{
    readonly IRegisterService registerServ = registerService;

    [HttpGet]
    public IEnumerable<Register> Get()
    {
        var result = registerServ.GetRegisters();
        return result;
    }

    [HttpPost]
    public IActionResult Post([FromBody]Register register)
    {
        var result = registerServ.UpsertRegister(register);
        return result ? Ok() : BadRequest();
    }
}
