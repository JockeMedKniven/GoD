
namespace GOD.Common.DTOs;

public class PublisherDTO
{
	public int Id { get; set; }
	public string? Name { get; set; }
}

public class PublisherListDTO : PublisherDTO
{
	public List<GameDTO> Games { get; set; } = null!;
}
public class PublisherCreateDTO
{
	public string? Name { get; set; }
}
public class PublisherEditDTO : PublisherCreateDTO
{
	public int Id { get; set; }
}