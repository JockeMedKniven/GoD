// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GOD.Membership.API.Controllers;

[Route("api/[controller]")]
[ApiController]

public class GenresController : ControllerBase
{
	private readonly IDbService db;

	public GenresController(IDbService db)
	{
		this.db = db;
	}
	// GET: api/<GenresController>
	[HttpGet]
	public async Task<IResult> Get()
	{
		try
		{
			List<GenreDTO> genre = await db.GetAsync<Genre, GenreDTO>();
			return Results.Ok(genre);

		}
		catch { }
		return Results.NotFound();
	}

	// GET api/<GenresController>/5
	[HttpGet("{id}")]
	public async Task<IResult> Get(int id)
	{
		try
		{
			var genre = await db.SingleAsync<Genre, GenreDTO>(a => a.Id.Equals(id));
			return Results.Ok(genre);
		}
		catch
		{ }
		return Results.NotFound();
	}

	// POST api/<GenresController>
	[HttpPost]
	public async Task<IResult> Post([FromBody] GenreCreateDTO dto)
	{
		try
		{
			if (dto == null) { return Results.BadRequest("No input"); }
			var genre = await db.AddAsync<Genre, GenreCreateDTO>(dto);
			var success = await db.SaveChangesAsync();
			if (!success) { return Results.BadRequest("Failed to save"); }
			return Results.Created(db.GetURI<Genre>(genre), genre);
		}
		catch { }
		return Results.BadRequest("Something went wrong");
	}

	// PUT api/<GenresController>/5
	[HttpPut("{id}")]
	public async Task<IResult> Put(int id, [FromBody] GenreEditDTO dto)
	{
		try
		{
			if (dto == null) { return Results.BadRequest("No genre provided"); }
			if (id != dto.Id) { return Results.BadRequest("Different ids"); }

			var exists = await db.AnyAsync<Genre>(i => i.Id == dto.Id);
			if (!exists) { return Results.NotFound("No related genre"); }

			db.Update<Genre, GenreEditDTO>(dto.Id, dto);

			var success = await db.SaveChangesAsync();

			if (!success) { return Results.BadRequest(); }
			return Results.NoContent();
		}
		catch { }
		return Results.BadRequest("Unable to update");
	}

	// DELETE api/<GenreController>/5
	[HttpDelete("{id}")]
	public async Task<IResult> Delete(int id)
	{
		try
		{
			var success = await db.DeleteAsync<Genre>(id);
			if (!success) { return Results.NotFound("The genre could not be found"); }

			success = await db.SaveChangesAsync();

			if (!success) { return Results.BadRequest("Something went wrong"); }
			return Results.NoContent();
		}
		catch { }
		return Results.BadRequest("Unable to delete");
	}
}
