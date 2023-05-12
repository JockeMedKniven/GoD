namespace GOD.Membership.Database.Contexts;

public class GODContext : DbContext
{
	public DbSet<Publisher> Publishers => Set<Publisher>();
	public DbSet<Game> Games => Set<Game>();
	public DbSet<Genre> Genres => Set<Genre>();
	public DbSet<GameGenre> GameGenres => Set<GameGenre>();
	public DbSet<SimilarGame> Sims => Set<SimilarGame>();

	public GODContext(DbContextOptions<GODContext> options) : base(options) { }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<SimilarGame>().HasKey(x => new { x.GameId, x.SimilarGameId });
		modelBuilder.Entity<GameGenre>().HasKey(x => new { x.GameId, x.GenreId });
		modelBuilder.Entity<Game>(entity =>
		{
			entity.HasMany(x => x.SimilarGames)
			.WithOne(x => x.Game)
			.HasForeignKey(x => x.GameId)
			.OnDelete(DeleteBehavior.Restrict);

			entity.HasMany(x => x.Genres)
			.WithMany(x => x.Games)
			.UsingEntity<GameGenre>()
			.ToTable("GameGenres");
		});

		base.OnModelCreating(modelBuilder);

		foreach (var relation in modelBuilder.Model.GetEntityTypes().SelectMany(e =>
		e.GetForeignKeys()))
		{
			relation.DeleteBehavior = DeleteBehavior.Restrict;
		}
	}
}
