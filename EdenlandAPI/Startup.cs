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
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
            services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new TimeSpanToStringConverter()));

            // use SQL Server
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("AppDbContext")));

            // add NewtonsoftJson
            services.AddMvc().AddNewtonsoftJson();

            // bind out service and repository to the respective classes
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IBeauticianRepository, BeauticianRepository>();
            services.AddScoped<ITreatmentRepository, TreatmentRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IBeauticianService, BeauticianService>();
            services.AddScoped<ITreatmentService, TreatmentService>();

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
