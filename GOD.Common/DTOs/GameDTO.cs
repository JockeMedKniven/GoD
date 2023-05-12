namespace GOD.Common.DTOs;

public class GameDTO
{
	public int Id { get; set; }
	public string? Title { get; set; }
	public int PublisherId { get; set; }
	public string? Description { get; set; }
	public string? GameUrl { get; set; }
	public DateTime Released { get; set; }
	public int HowLongToBeat { get; set; }
	public bool Free { get; set; }
	public int[] SelectedGenres { get; set; } = null!;


	public List<SimilarGameDTO> SimilarGames { get; set; } = null!;
	public List<GenreBaseDTO> Genres { get; set; } = null!;
	public PublisherDTO Publisher { get; set; } = null!;
}
public class GameCreateDTO
{
	public string? Title { get; set; }
	public int PublisherId { get; set; }
	public string? Description { get; set; }
	public string? GameUrl { get; set; }
	public DateTime Released { get; set; }
	public int HowLongToBeat { get; set; }
	public bool Free { get; set; }
	public int[] SelectedGenres { get; set; } = null!;
}
public class GameEditDTO : GameCreateDTO
{
	public int Id { get; set; }
}
