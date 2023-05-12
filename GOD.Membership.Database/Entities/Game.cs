namespace GOD.Membership.Database.Entities;

public class Game : IEntity
{
	public Game()
	{
		SimilarGames = new HashSet<SimilarGame>();
		Genres = new HashSet<Genre>();
	}

	public int Id { get; set; }
	[MaxLength(50), Required]
	public string? Title { get; set; }
	public int PublisherId { get; set; }
	[MaxLength(2024), Required]
	public string? Description { get; set; }
	[MaxLength(2024)]
	public string? GameUrl { get; set; }
	public DateTime Released { get; set; }
	public int HowLongToBeat { get; set; }
	public bool Free { get; set; }

	public virtual ICollection<SimilarGame> SimilarGames { get; set; }
	public virtual ICollection<Genre> Genres { get; set; }
	public virtual Publisher Publisher { get; set; } = null!;
}