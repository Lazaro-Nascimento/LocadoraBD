using System.Data.Common;
using Locadora.Data;
using Locadora.Models;
using Locadora.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Locadora.Controllers;
[ApiController]
[Route("[controller]")]
public class LocadoraController : ControllerBase{
    readonly GameServices gameServices;
    public LocadoraController(GameServices gameServices)
    {
        this.gameServices = gameServices;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Game>> GetAll()
    {
        return Ok(gameServices.GetAll());
    }
    [HttpGet("{id}")]
    public ActionResult<Game> GetById(int id)
    {
        Game? game = gameServices.GetGame(id);
        if(game != null){
            return Ok(game);
        }
        return BadRequest("Id inesxistente!");
    }
    [HttpPost]
    public ActionResult Post(Game game){
        if(gameServices.CreateGame(game) == true)
            return Ok();
        else
            return BadRequest("Jogo Inválido!!");
    }
    [HttpDelete("{id}")]0
    public ActionResult Delete(int id)
    {
        Game? game = gameServices.DeleteGame(id);
        if(game != null)
            return Ok($"O jogo {game.Name} foi deletado com sucesso!");
        else
            return BadRequest("Id de jogo inválido!");
    }

}