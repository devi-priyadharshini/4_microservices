using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(); 

// Options Pattern to read application configurations from Configuration file.
builder.Services.AddOptions<CommandService>().BindConfiguration(nameof(CommandService));

builder.Services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("InMem"));
builder.Services.AddScoped<IPlatformRepo, PlatformRepo>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddHttpClient<ICmdServiceHttpClient, CmdServiceHttpClient>();

var app = builder.Build();

app.UseHttpsRedirection();   

app.UseAuthorization();

app.MapControllers();

PrepDb.PopulateDB(app);

app.Run();
