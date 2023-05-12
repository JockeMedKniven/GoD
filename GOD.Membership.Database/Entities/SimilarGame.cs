using GOD.Membership.Database.Services;
using System.ComponentModel.DataAnnotations.Schema;

namespace GOD.Membership.Database.Entities;

public class SimilarGame : IReferenceEntity
{
	public int GameId { get; set; }
	public int SimilarGameId { get; set; }

	public virtual Game Game { get; set; } = null!;
	[ForeignKey("SimilarGameId")]
	public virtual Game Similar { get; set; } = null!;
}
