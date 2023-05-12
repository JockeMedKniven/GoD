namespace GOD.Common.Models;

public class GameModel
{
	public int Id { get; set; }
	public string? Title { get; set; }
	public string? Description { get; set; }
	public string? GameUrl { get; set; }
	public DateTime Released { get; set; }
	public int HowLongToBeat { get; set; }
	public bool Free { get; set; }

	public int PublisherId { get; set; }
}
