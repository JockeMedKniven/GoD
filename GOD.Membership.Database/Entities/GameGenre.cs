using GOD.Membership.Database.Services;

namespace GOD.Membership.Database.Entities;

public class GameGenre : IReferenceEntity
{
	public int GameId { get; set; }
	public int GenreId { get; set; }

	public virtual Game Game { get; set; } = null!;
	public virtual Genre Genre { get; set; } = null!;
}
