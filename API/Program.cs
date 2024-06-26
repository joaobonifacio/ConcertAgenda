using API.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

//EXTENSION METHOD
builder.Services.AddApplicationServices(builder.Configuration);

//Sql Server connection
// builder.Services.AddDbContext<ConcertsAgendaContext>(options =>
//     options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

//CORS
app.UseCors("CorsPolicy");

//app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();
