using GOD.Membership.Database.Contexts;
using GOD.Membership.Database.Entities;
using GOD.Membership.Database.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(policy =>
{
	policy.AddPolicy("CorsAllAccessPolicy", opt =>
	opt.AllowAnyOrigin()
	.AllowAnyHeader()
	.AllowAnyMethod()
	);
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

ConfigureAutomapper(builder.Services);
builder.Services.AddScoped<IDbService, DbService>();

builder.Services.AddDbContext<GODContext>(
options => options.UseSqlServer(
 builder.Configuration.GetConnectionString("GODConnection")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("CorsAllAccessPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();

void ConfigureAutomapper(IServiceCollection services)
{
	var config = new MapperConfiguration(cfg =>
	{
		cfg.CreateMap<Publisher, PublisherDTO>().ReverseMap()
		.ForMember(dest => dest.Games, src => src.Ignore());

		cfg.CreateMap<Game, GameDTO>().ReverseMap()
		.ForMember(dest => dest.Publisher, src => src.Ignore());

		cfg.CreateMap<Genre, GenreDTO>().ReverseMap()
		.ForMember(dest => dest.Games, src => src.Ignore());
		//
		cfg.CreateMap<Genre, GenreBaseDTO>().ReverseMap();
		//
		cfg.CreateMap<GameGenre, GameGenreDTO>().ReverseMap();

		cfg.CreateMap<SimilarGame, SimilarGameDTO>().ReverseMap();
		cfg.CreateMap<SimilarGameKeyDTO, SimilarGame> ().ReverseMap();

		cfg.CreateMap<GameCreateDTO, Game>()
		.ForMember(dest => dest.Publisher, src => src.Ignore())
		.ForMember(dest => dest.Genres, src => src.Ignore());

		cfg.CreateMap<GameEditDTO, Game>()
		.ForMember(dest => dest.Publisher, src => src.Ignore())
		.ForMember(dest => dest.Genres, src => src.Ignore());

		cfg.CreateMap<GenreCreateDTO, Genre>();
		cfg.CreateMap<GenreEditDTO, Genre>();

		cfg.CreateMap<PublisherCreateDTO, Publisher>();
		cfg.CreateMap<PublisherEditDTO, Publisher>();

	});
	var mapper = config.CreateMapper();
	services.AddSingleton(mapper);
}
