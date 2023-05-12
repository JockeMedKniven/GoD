
namespace GOD.Common.DTOs;

public class GenreBaseDTO
{
	public int Id { get; set; }
	public string? Name { get; set; }
}
public class GenreDTO : GenreBaseDTO
{
	public List<GameDTO> Games { get; set; } = null!;
}
public class GenreCreateDTO
{
	public string? Name { get; set; }
}
public class GenreEditDTO : GenreCreateDTO
{
	public int Id { get; set; }
}

