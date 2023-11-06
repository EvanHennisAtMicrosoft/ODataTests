using Microsoft.AspNetCore.OData;
using Microsoft.AspNetCore.OData.Edm;
using WebApplication3.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var model = EdmModelBuilder.GetEdmModel();

builder.Services.AddControllers().
    AddOData(opt => opt.AddRouteComponents("odata", model).EnableQueryFeatures());

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseODataRouteDebug();

app.UseAuthorization();

app.MapControllers();

app.Run();
