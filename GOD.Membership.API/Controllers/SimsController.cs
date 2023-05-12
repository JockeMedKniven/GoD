using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GOD.Membership.API.Controllers;

[Route("api/SimsController")]
[ApiController]
public class SimsController : ControllerBase
{
	private readonly IDbService db;

	public SimsController(IDbService db)
	{
		this.db = db;
	}
	// GET: api/<SimsController>
	[HttpGet]
	public async Task<IResult> Get()
	{
		try
		{
			db.Include<Game>();
			db.IncludeRef<SimilarGame>();
			List<SimilarGameKeyDTO> simsGame = await db.GetRefAsync<SimilarGame, SimilarGameKeyDTO>();

			return Results.Ok(simsGame);
		}
		catch { }
		return Results.NotFound();
	}

	// POST api/<SimsController>
	[HttpPost]
	public async Task<IResult> Post([FromBody] SimilarGameDTO dto)
	{
		try
		{
			if (dto == null) { return Results.BadRequest(); }
			var simGame = await db.AddAsync<SimilarGame, SimilarGameDTO>(dto);
			if (await db.SaveChangesAsync() == false) return Results.BadRequest();
			return Results.Created("Simscontroller", simGame);

		}
		catch
		{ }
		return Results.BadRequest();
	}


	// DELETE api/<SimsController>/5
	[HttpDelete]
	public async Task<IResult> Delete(SimilarGameDTO dto)
	{
		try
		{
			//var sims = new SimilarGame();
			//sims.GameId = dto.GameId;
			//sims.SimiliarGameId = dto.SimiliarGameId;
			var remove = db.DeleteRef<SimilarGame, SimilarGameDTO>(dto);
			await db.SaveChangesAsync();
			return Results.Ok(remove);
		}
		catch (Exception)
		{

			throw;
		}
	}
}
