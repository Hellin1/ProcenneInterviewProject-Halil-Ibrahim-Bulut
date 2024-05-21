using Microsoft.AspNetCore.Diagnostics;
using Persistance;
using Application;
using BudgetPlanner.Application.Responses;
using BudgetPlanner.Application.Helpers;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplicationService();
builder.Services.AddPersistanceServices(builder.Configuration);


//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
//{
//    opt.RequireHttpsMetadata = false;
//    opt.TokenValidationParameters = new TokenValidationParameters
//    {
//        ValidAudience = JwtTokenDefaults.ValidAudience,
//        ValidIssuer = JwtTokenDefaults.ValidIssuer,
//        ClockSkew = TimeSpan.Zero,
//        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.Key)),
//        ValidateLifetime = true,
//        ValidateIssuerSigningKey = true
//    };
//});


var app = builder.Build();

app.UseExceptionHandler(appError =>
{
    appError.Run(async context =>
    {
        var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
        if (contextFeature != null)
        {
            context.Response.StatusCode = 200;
            await context.Response.WriteAsync(new ResultModel<object>
            {
                IsSuccessful = false,
                Errors = new List<ErrorModel>
                            {
                                new ErrorModel
                                {
                                    ErrorCode = "1001",
                                    ErrorMessage = contextFeature.Error.Message
                                }
                            },
                Result = null
            }.ToJson());

        }
    });
});

app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(x =>
    {
        x.DisplayRequestDuration();
    });
}
app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors();
app.MapControllers();

app.Run();
