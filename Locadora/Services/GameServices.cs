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
    public bool CreateGame(Game game)
    {
        if(game != null){
            if(!String.IsNullOrWhiteSpace(game.Name) && game.LimitAge > 0 && game.LimitAge <= 18 && DateTime.MinValue <= game.ReleaseDate)
            {   
                game.Id = 0;     
                _context.Games.Add(game);
                _context.SaveChanges();
                return true;
            }
        }
        return false;
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
    public Game? DeleteGame(int id){
        Game? game = _context.Games.SingleOrDefault(G => G.Id == id);
        if(game != null)
        {
            _context.Games.Remove(game);
        }
        _context.SaveChanges();
        return game;
    }
}