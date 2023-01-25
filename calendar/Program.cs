global using calendar.Data;
using calendar.Services.ClientMissionService;
using calendar.Services.ClientService;
using calendar.Services.EventService;
using calendar.Services.MissionService;
using calendar.Services.TravailService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<ITravailService, TravailService>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IMissionService, MissionService>();
builder.Services.AddScoped<IClientMissionService, ClientMissionService>();
builder.Services.AddDbContext<DataContext>();

builder.Services.AddCors(p => p.AddPolicy("corspolicy", build =>
{
    build.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("corspolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
