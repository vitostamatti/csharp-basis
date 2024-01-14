using MicroIMS.Api;
using MicroIMS.Application;
using MicroIMS.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

{
    builder.Services
        .AddPresentation()
        .AddApplication()
        .AddInfrastructure(builder.Configuration);
}

var app = builder.Build();

{
    // using (var scope = app.Services.CreateScope())
    // {
    //     var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    //     db.Database.Migrate();
    // }
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}