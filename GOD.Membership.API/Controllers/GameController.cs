// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

using GOD.Membership.Database.Entities;

namespace GOD.Membership.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GameController : ControllerBase
{
	private readonly IDbService db;

	public GameController(IDbService db)
	{
		this.db = db;
	}
	// GET: api/<GameController>
	[HttpGet]
	public async Task<IResult> Get(bool freeOnly)
	{
		try
		{
			db.Include<Game>();
			db.IncludeRef<GameGenre>();
			List<GameDTO> games = await db.GetBoolAsync<Game, GameDTO>(
				s => s.Free.Equals(freeOnly));
			if (!freeOnly)
			{
				games = await db.GetAsync<Game, GameDTO>();
			}
			return Results.Ok(games);

		}
		catch { }
		return Results.NotFound();
	}

	// GET api/<GameController>/5
	[HttpGet("{id}")]
	public async Task<IResult> Get(int id)
	{
		try
		{
			db.Include<Publisher>();
			db.Include<Genre>();
			db.Include<Game>();
			var game = await db.SingleAsync<Game, GameDTO>(s => s.Id.Equals(id));
			return Results.Ok(game);
		}
		catch
		{ }
		return Results.NotFound();
	}

	// POST api/<GameController>
	[HttpPost]
	public async Task<IResult> Post([FromBody] GameCreateDTO dto)
	{
		try
		{
			if (dto == null) { return Results.BadRequest(); }
			var game = await db.AddAsync<Game, GameCreateDTO>(dto);
			var success = await db.SaveChangesAsync();
			if (success == false) { return Results.BadRequest(); }
			//-----------------------------------------------------
			foreach (var genre in dto.SelectedGenres) 
			{
				var gg = new GameGenreDTO
				{
					GameId = game.Id,
					GenreId = genre
				};
				await db.AddAsync<GameGenre, GameGenreDTO>(gg);
			}
			success = await db.SaveChangesAsync();
			//-----------------------------------------------------
			
			if (success == false) { return Results.BadRequest(); }
			return Results.Created(db.GetURI<Game>(game), game);

		}
		catch
		{ }
		return Results.BadRequest();
	}

	// PUT api/<GameController>/5
	[HttpPut("{id}")]
	public async Task<IResult> Put(int id, [FromBody] GameEditDTO dto)
	{
		try
		{
			if (dto == null) { return Results.BadRequest("No game provided"); }
			if (id != dto.Id) { return Results.BadRequest("Different ids"); }

			var exists = await db.AnyAsync<Publisher>(i => i.Id == dto.PublisherId);
			if (!exists) { return Results.NotFound("No related publisher"); }

			exists = await db.AnyAsync<Game>(s => s.Id == id);
			if (!exists) { return Results.NotFound("No game located"); }

			db.Update<Game, GameEditDTO>(dto.Id, dto);

			var success = await db.SaveChangesAsync();

			//----------------------------------------------
			foreach (var genre in dto.SelectedGenres)
			{
				var gg = new GameGenreDTO
				{
					GameId = dto.Id,
					GenreId = genre
				};
				await db.AddAsync<GameGenre, GameGenreDTO>(gg);
			}
			success = await db.SaveChangesAsync();
			//----------------------------------------------


			if (!success) { return Results.BadRequest(); }
			return Results.NoContent();
		}
		catch { }
		return Results.BadRequest("unable to update the game");
	}

	// DELETE api/<GameController>/5
	[HttpDelete("{id}")]
	public async Task<IResult> Delete(int id)
	{
		try
		{
			var success = await db.DeleteAsync<Game>(id);
			if (!success) { return Results.NotFound("The game could not be found"); }

			success = await db.SaveChangesAsync();

			if (!success) { return Results.BadRequest("Something went wrong"); }
			return Results.NoContent();
		}
		catch { }
		return Results.BadRequest("Unable to delete");
	}
}
