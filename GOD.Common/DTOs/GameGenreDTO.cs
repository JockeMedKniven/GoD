using GOD.Common.DTOs;

public class GameGenreDTO
{
	public int GameId { get; set; }
	public int GenreId { get; set; }

}

public class GameGenreDTOS : GameGenreDTO
{
	public GameDTO Game { get; set; } = null!;
	public GenreDTO Genre { get; set; } = null!;
}
