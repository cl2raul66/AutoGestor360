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
    public IEnumerable<Register> Get() => registerServ.GetAll().Reverse();

    [HttpGet("{id}")]
    public Register GetById([FromRoute] string id)
    {
        var result = registerServ.GetById(id);
        return result;
    }

    [HttpPost]
    public IActionResult Post([FromBody] Register register)
    {
        var result = registerServ.Upsert(register);
        return result ? Ok() : BadRequest();
    }

    [HttpGet]
    [Route("exist")]
    public bool Exist() => registerServ.Exist;

    [HttpGet]
    [Route("getnewindex")]
    public int GetNewIndex()
    {
        int resul = 1;
        if (Exist())
        {
            var allIds = registerServ.GetAll().Select(x => int.Parse(x.Id!.Split("-").Last())).OrderBy(x => x).ToList();

            for (int i = 0; i < allIds.Count; i++)
            {
                if (allIds[i] != i + 1)
                {
                    resul = i + 1;
                    break;
                }
                else if (i == allIds.Count - 1)
                {
                    resul = i + 2;
                }
            }
        }

        return resul;
    }

    [HttpDelete("{id}")]
    public IActionResult Delete([FromRoute] string id)
    {
        bool isDeleted = registerServ.Delete(id);
        return isDeleted ? Ok() : NotFound();
    }

}
