using MagicVilla_VillaAPI.Extensions;
using MagicVilla_VillaAPI.Logging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCustomLogger();
builder.Services.AddControllers();
/*builder.Host.UseSerilog();
builder.Services.AddControllers(option => {
    option.ReturnHttpNotAcceptable = true;
    }).AddNewtonsoftJson().AddXmlDataContractSerializerFormatters();
builder.Services.AddSingleton<ILogging, Logging>();   
*/
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
