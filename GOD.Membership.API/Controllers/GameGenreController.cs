using GOD.Membership.Database.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GOD.Membership.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GameGenreController : ControllerBase
{
	private readonly IDbService db;

	public GameGenreController(IDbService db)
	{
		this.db = db;
	}

	// GET: api/<GameGenreController>
	[HttpGet]
	public async Task<IResult> Get()
	{
		try
		{
			var gameGenre = await db.GetRefAsync<GameGenre, GameGenreDTO>();
			return Results.Ok(gameGenre);
		}
		catch (Exception)
		{
			throw;
		}
	}

	//// POST api/<GameGenreController>
	//[HttpPost]
	//public async Task<IResult> Post([FromBody] GameGenreDTO dto)
	//{
	//	try
	//	{
	//		if (dto == null) { return Results.BadRequest("No input"); }
	//		var gameGenre = await db.AddAsync<GameGenre, GameGenreDTO>(dto);
	//		var success = await db.SaveChangesAsync();
	//		if (!success) { return Results.BadRequest("Failed to save"); }

	//	}
	//	catch { }
	//	return Results.BadRequest("Something went wrong");
	//}


	// DELETE api/<GameGenreController>/5
	[HttpDelete]
	public async Task<IResult> Delete([FromBody] GameGenreDTO dto)
	{
		try
		{
			var success = db.DeleteRef<GameGenre, GameGenreDTO>(dto);
			if (!success) { return Results.NotFound("The game could not be found"); }

			success = await db.SaveChangesAsync();

			if (!success) { return Results.BadRequest("Something went wrong"); }
			return Results.NoContent();
		}
		catch { }
		return Results.BadRequest("Unable to delete");
	}
}