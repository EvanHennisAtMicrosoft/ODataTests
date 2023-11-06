using Microsoft.AspNetCore.OData;
using Microsoft.AspNetCore.OData.Edm;
using Microsoft.AspNetCore.OData.Formatter.Serialization;
using WebApplication3.Extensions;
using WebApplication3.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var model = EdmModelBuilder.GetEdmModel();

builder.Services.AddControllers().
    AddOData(opt => opt.AddRouteComponents("odata", model,
    services => services.AddSingleton<ODataResourceSetSerializer, MyResourceSetSerializer>()).EnableQueryFeatures());

builder.Services.AddSingleton<IPageSizeProvider>(sp => new PageSizeProvider(3));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseODataRouteDebug();

app.UseAuthorization();

app.MapControllers();

app.Run();
