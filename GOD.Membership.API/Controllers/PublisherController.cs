// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GOD.Membership.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PublisherController : ControllerBase
{
	private readonly IDbService db;

	public PublisherController(IDbService db)
	{
		this.db = db;
	}
	// GET: api/<PublisherController>
	[HttpGet]
	public async Task<IResult> Get()
	{
		try
		{
			List<PublisherDTO> publisher = await db.GetAsync<Publisher, PublisherDTO>();
			return Results.Ok(publisher);

		}
		catch { }
		return Results.NotFound();
	}

	// GET api/<PublisherController>/5
	[HttpGet("{id}")]
	public async Task<IResult> Get(int id)
	{
		try
		{
			var publisher = await db.SingleAsync<Publisher, PublisherDTO>(a => a.Id.Equals(id));
			return Results.Ok(publisher);
		}
		catch
		{ }
		return Results.NotFound();
	}

	// POST api/<PublisherController>
	[HttpPost]
	public async Task<IResult> Post([FromBody] PublisherCreateDTO dto)
	{
		try
		{
			if (dto == null) { return Results.BadRequest("No input"); }
			var publisher = await db.AddAsync<Publisher, PublisherCreateDTO>(dto);
			var success = await db.SaveChangesAsync();
			if (!success) { return Results.BadRequest("Failed to save"); }
			return Results.Created(db.GetURI<Publisher>(publisher), publisher);
		}
		catch { }
		return Results.BadRequest("Something went wrong");
	}

	// PUT api/<PublisherController>/5
	[HttpPut("{id}")]
	public async Task<IResult> Put(int id, [FromBody] PublisherEditDTO dto)
	{
		try
		{
			if (dto == null) { return Results.BadRequest("No publisher provided"); }
			if (id != dto.Id) { return Results.BadRequest("Different ids"); }

			var exists = await db.AnyAsync<Publisher>(i => i.Id == dto.Id);
			if (!exists) { return Results.NotFound("No related publisher"); }

			db.Update<Publisher, PublisherEditDTO>(dto.Id, dto);

			var success = await db.SaveChangesAsync();

			if (!success) { return Results.BadRequest(); }
			return Results.NoContent();
		}
		catch { }
		return Results.BadRequest("Unable to update");
	}

	// DELETE api/<PublisherController>/5
	[HttpDelete("{id}")]
	public async Task<IResult> Delete(int id)
	{
		try
		{
			var success = await db.DeleteAsync<Publisher>(id);
			if (!success) { return Results.NotFound("The publisher could not be found"); }

			success = await db.SaveChangesAsync();

			if (!success) { return Results.BadRequest("Something went wrong"); }
			return Results.NoContent();
		}
		catch { }
		return Results.BadRequest("Unable to delete");
	}
}
