namespace GOD.Membership.Database.Entities;

public class Genre : IEntity
{
	public Genre()
	{
		Games = new HashSet<Game>();
	}
	public int Id { get; set; }
	[MaxLength(24), Required]
	public string? Name { get; set; }

	public virtual ICollection<Game> Games { get; set; }
}
