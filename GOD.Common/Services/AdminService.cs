using System.Net.Http.Json;

namespace GOD.Common.Services;

public class AdminService : IAdminService
{
	private readonly MembershipHttpClient http;

	public AdminService(MembershipHttpClient httpClient)
	{
		http = httpClient;
	}

	public async Task<List<TDto>> GetAsync<TDto>(string uri)
	{
		try
		{
			using HttpResponseMessage response = await http.Client.GetAsync(uri);
			response.EnsureSuccessStatusCode();

			var result = JsonSerializer.Deserialize<List<TDto>>(await response.Content.ReadAsStreamAsync(),
			new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

			return result ?? new List<TDto>();
		}
		catch (Exception ex) { throw; }
	}

	public async Task<TDto> SingleAsync<TDto>(string uri)
	{
		try
		{
			using HttpResponseMessage response = await http.Client.GetAsync(uri);
			response.EnsureSuccessStatusCode();

			var result = JsonSerializer.Deserialize<TDto>(await response.Content.ReadAsStreamAsync(),
			new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

			return result ?? default;
		}
		catch (Exception ex) { throw; }
	}

	public async Task CreateAsync<TDto>(string uri, TDto dto)
	{
		try
		{
			using StringContent jsonContent = new(JsonSerializer.Serialize(dto),
				Encoding.UTF8, "application/json");

			using HttpResponseMessage response = await http.Client.PostAsync(uri, jsonContent);
			response.EnsureSuccessStatusCode();
		}
		catch (Exception)
		{

			throw;
		}
	}
	public async Task EditAsync<TDto>(string uri, TDto dto)
	{
		try
		{
			using StringContent jsonContent = new(JsonSerializer.Serialize(dto),
				Encoding.UTF8, "application/json");

			using HttpResponseMessage response = await http.Client.PutAsync(uri, jsonContent);
			response.EnsureSuccessStatusCode();
		}
		catch (Exception)
		{

			throw;
		}
	}
	public async Task DeleteAsync<TDto>(string uri)
	{
		try
		{
			using HttpResponseMessage response = await http.Client.DeleteAsync(uri);
			response.EnsureSuccessStatusCode();
		}
		catch (Exception)
		{
			throw;
		}
	}


	//Kolla på detta!!!!!!!!
	public async Task DeleteRefAsync<TDto>(string uri, TDto dto)
	{
		try
		{
			var code = new HttpRequestMessage(HttpMethod.Delete, uri);
			code.Content = JsonContent.Create(dto);
			using HttpResponseMessage response = await http.Client.SendAsync(code);
			response.EnsureSuccessStatusCode();
		}
		catch (Exception)
		{
			throw;
		}
	}
}
