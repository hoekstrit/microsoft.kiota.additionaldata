using Asp.Versioning;

namespace Kiota.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddProblemDetails();

            builder.Services.AddControllers();


            // Api Versioning
            builder.Services.AddApiVersioning(opt =>
            {
                opt.ReportApiVersions = true;
                opt.ApiVersionReader = ApiVersionReader.Combine(new UrlSegmentApiVersionReader());
            }).AddApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });

            // Open API
            builder.Services.AddOpenApiDocument(options =>
            {
                options.DocumentName = "v1";
                options.ApiGroupNames = ["v1"];
                options.Title = "Kiota.Api";
            });

            var app = builder.Build();

            app.UseExceptionHandler();
            app.UseStatusCodePages();
            app.UseOpenApi();
            app.MapControllers();

            app.Run();
        }
    }
}
