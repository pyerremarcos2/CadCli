using CadCli.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace CadCli.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ClientesController : ControllerBase
{

    private static List<Cliente> dados = new List<Cliente> {

        new Cliente{Id=1, Nome= "Fabiano Nalin", Idade = 43, Sexo = "Masculino"},
        new Cliente{Id=2, Nome= "Priscila Mitui", Idade = 44, Sexo = "Feminino"},
        new Cliente{Id=3, Nome= "Raphael Akyu", Idade = 23, Sexo = "Masculino"},
        new Cliente {Id=4, Nome= "Nair Goes", Idade = 80, Sexo = "Feminino"},
    };

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(dados);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var cliente = dados.FirstOrDefault(x => x.Id == id);
        if (cliente is null) return NotFound();

        return Ok(cliente);
    }

    [HttpPost]
    public IActionResult Add([FromBody] Cliente model)
    {
        model.Id = (dados.LastOrDefault()?.Id ?? 0) + 1;
        dados.Add(model);
        return Ok(model);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] Cliente model)
    {
        var cliente = dados.FirstOrDefault(x => x.Id == id);

        if (cliente is null) {
            return BadRequest();
        }
        
        cliente.Nome = model.Nome;
        cliente.Idade = model.Idade;
        cliente.Sexo = model.Sexo;
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var cliente = dados.FirstOrDefault(x => x.Id == id);

        if (cliente is null) {
            return BadRequest();
        }
        
        dados.Remove(cliente);
        return NoContent();
    }
}
