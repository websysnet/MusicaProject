var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire client integrations.
builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddProblemDetails();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapGet("/", () => "API service is running. Navigate to /bienvenida to see sample data.");

app.MapGet("/bienvenida", () => "¡Bienvenido a la API de MusicaProject! Aquí puedes encontrar información sobre tus artistas, álbumes y canciones favoritas. Explora nuestros endpoints para descubrir más sobre el mundo de la música.");


app.MapGet("/artistas", () =>
{
    var artistas = new[]
    {
        new { Id = 1, Nombre = "The Beatles", Genero = "Rock" },
        new { Id = 2, Nombre = "Beyoncé", Genero = "Pop" },
        new { Id = 3, Nombre = "Miles Davis", Genero = "Jazz" }
    };
    return artistas;
}).WithName("GetArtistas");

app.MapGet("/albumes", () =>
{
    var albumes = new[]
    {
        new { Id = 1, Titulo = "Abbey Road", ArtistaId = 1 },
        new { Id = 2, Titulo = "Lemonade", ArtistaId = 2 },
        new { Id = 3, Titulo = "Kind of Blue", ArtistaId = 3 }
    };
    return albumes;
}).WithName("GetAlbumes");

app.MapGet("/canciones", () =>
{
    var canciones = new[]
    {
        new { Id = 1, Titulo = "Come Together", AlbumId = 1 },
        new { Id = 2, Titulo = "Formation", AlbumId = 2 },
        new { Id = 3, Titulo = "So What", AlbumId = 3 }
    };
    return canciones;
}).WithName("GetCanciones");


app.MapGet("/artistas/{id}", (int id) =>
{
    var artista = new { Id = id, Nombre = $"Artista {id}", Genero = "Desconocido" };
    return artista;
}).WithName("GetArtistaById");


app.MapGet("/albumes/{id}", (int id) =>
{
    var album = new { Id = id, Titulo = $"Álbum {id}", ArtistaId = 0 };
    return album;
}).WithName("GetAlbumById");  


app.MapGet("/canciones/{id}", (int id) =>
{
    var cancion = new { Id = id, Titulo = $"Canción {id}", AlbumId = 0 };
    return cancion;
}).WithName("GetCancionById");

app.MapGet("/bares", () =>
{
    var bares = new[]
    {
        new { Id = 1, Nombre = "Bar de Jazz", Ubicacion = "Centro" },
        new { Id = 2, Nombre = "Bar de Rock", Ubicacion = "Norte" },
        new { Id = 3, Nombre = "Bar de Pop", Ubicacion = "Sur" }
    };
    return bares;
}).WithName("GetBares");

app.MapGet("/bares/{id}", (int id) =>
{
    var bar = new { Id = id, Nombre = $"Bar {id}", Ubicacion = "Desconocida" };
    return bar;
}).WithName("GetBarById");

app.MapGet("/eventos", () =>
{
    var eventos = new[]
    {
        new { Id = 1, Nombre = "Concierto de Jazz", Fecha = DateTime.Now.AddDays(10) },
        new { Id = 2, Nombre = "Festival de Rock", Fecha = DateTime.Now.AddDays(20) },
        new { Id = 3, Nombre = "Noche de Pop", Fecha = DateTime.Now.AddDays(30) }
    };
    return eventos;
}).WithName("GetEventos");  

app.MapGet("/eventos/{id}", (int id) =>
{
    var evento = new { Id = id, Nombre = $"Evento {id}", Fecha = DateTime.Now.AddDays(0) };
    return evento;
}).WithName("GetEventoById");

app.MapDefaultEndpoints();

app.Run();


public record Artista(int Id, string Nombre, string Genero);
public record Album(int Id, string Titulo, int ArtistaId);
public record Cancion(int Id, string Titulo, int AlbumId);
public record Bar(int Id, string Nombre, string Ubicacion);
public record Evento(int Id, string Nombre, DateTime Fecha);

