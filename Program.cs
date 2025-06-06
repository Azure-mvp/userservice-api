var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllFrontends",
        policy =>
        {
            policy.WithOrigins("http://localhost:5173",
                "https://witty-mushroom-0bf17e710.6.azurestaticapps.net"
                )
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseCors("AllowAllFrontends");

app.UseAuthorization();

app.MapControllers();

app.Run();
