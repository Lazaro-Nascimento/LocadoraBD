using Locadora.Data;
using Locadora.Models;

namespace Locadora.Services;

public class GameServices{
    private readonly LocadoraContext _context;

    public GameServices(LocadoraContext context){
        _context = context;
    }
    public IEnumerable<Game> GetAll()
    {
        return _context.Games.ToList();
    }
    public Game? GetGame(int id)
    {
        return _context.Games.SingleOrDefault(G => G.Id == id);
    }
    public void CreateGame(Game game)
    {
        if(game != null){
            if(!String.IsNullOrWhiteSpace(game.Name))
                game.Name = game.Name;
            
            if(game.LimitAge < 0 || game.LimitAge > 18)
                game.LimitAge = game.LimitAge;

            if(DateTime.MinValue <= game.ReleaseDate)
                game.ReleaseDate = game.ReleaseDate;
        
            _context.Games.Add(game);
            _context.SaveChanges();
        }
    }
    public Game? UpdateGame(int id, Game gameUpt)
    {
        Game? game = _context.Games.SingleOrDefault(G => G.Id == id);

        if(game != null){
            if(!String.IsNullOrWhiteSpace(gameUpt.Name))
                game.Name = gameUpt.Name;
            
            if(gameUpt.LimitAge < 0 || gameUpt.LimitAge > 18)
                game.LimitAge = gameUpt.LimitAge;

            if(DateTime.MinValue <= gameUpt.ReleaseDate)
                game.ReleaseDate = gameUpt.ReleaseDate;
        }
        _context.SaveChanges();
        return game;
    }
}