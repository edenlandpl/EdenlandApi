using AutoMapper;
using EdenlandAPI.DataContext.Context;
using EdenlandAPI.DataContext.Repositories;
using EdenlandAPI.DataContext.Repositories.Beautician;
using EdenlandAPI.Domain.Repositories;
using EdenlandAPI.Domain.Repositories.Beautician;
using EdenlandAPI.Domain.Services;
using EdenlandAPI.Domain.Services.Beautician;
using EdenlandAPI.Extensions.Converters;
using EdenlandAPI.Services;
using EdenlandAPI.Services.Beautician;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Buffers;

namespace EdenlandAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // MVCpipeline, which basicly means the application is going to handle rewuest and responses using controller classes
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddControllers();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            // configure database context, we tell Core to use out AppDbContext with in=memory database implementation, identified by the string as argument


            //// configuration this lines onternally congigures our database context for dependency injection using a scoped lifetime
            //services.AddDbContext<AppDbContext>(options => { options.UseInMemoryDatabase("edenlandapi-in-memory"); });

            // register converter for TimeSpan Json
            services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new TimeSpanToStringConverter())) ;

            // line to ignore loop in json answer
            services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            // use SQL Server
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("AppDbContext")));

            // add NewtonsoftJson
            services.AddMvc().AddNewtonsoftJson();

            // bind out service and repository to the respective classes
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IBeauticianRepository, BeauticianRepository>();
            services.AddScoped<ITreatmentRepository, TreatmentRepository>();
            services.AddScoped<IBeauticiansTreatmentsRepository, BeauticiansTreatmentsRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IBeauticianService, BeauticianService>();
            services.AddScoped<ITreatmentService, TreatmentService>();
            services.AddScoped<IBeauticiansTreatmentsService, BeauticiansTreatmentsService>();

            // dodane zosta³o typeof(Startup) - poniewa¿ nie chcia³o siê kompilowaæ
            services.AddAutoMapper(typeof(Startup));
                // wersja druga rozwi¹zania problemu nie kompilowania services.AddAutoMapper()
                //var config = new AutoMapper.MapperConfiguration(cfg =>
                //{
                //    cfg.AddProfile(new MappingProfile());
                //});

                //var mapper = config.CreateMapper();
                //services.AddSingleton(mapper);

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseHttpsRedirection();
            //app.UseMvc();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
