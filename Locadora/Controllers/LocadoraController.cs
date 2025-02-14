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
        gameServices.CreateGame(game);
        return Ok();
    }

}