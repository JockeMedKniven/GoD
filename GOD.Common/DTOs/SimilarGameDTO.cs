
namespace GOD.Common.DTOs;

public class SimilarGameDTO
{
	public int GameId { get; set; }
	public int SimilarGameId { get; set; }

	
}

public class SimilarGameKeyDTO : SimilarGameDTO
{
	public GameDTO Game { get; set; } = null!;
	[ForeignKey("SimilarGameId")]
	public GameDTO Similar { get; set; } = null!;
}
