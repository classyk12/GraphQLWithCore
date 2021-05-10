using System.Reflection;
using AutoMapper;
using graphql.models;
using graphql.repository;
using graphql.viewmodels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace graphql
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        private static void InitializeMapper()
        {
            Mapper.Initialize(x =>
            {
                //{
                //    x.CreateMap<Guest, GuestModel>();
                //    x.CreateMap<Room, RoomModel>();
                x.CreateMap<Reservation, ReservationModel>();
            });
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //add dbcontext
            services.AddDbContext<MyHotelDbContext>(options => options.UseSqlServer(MyHotelDbContext.DbConnectionString));     
            //add repository
            services.AddTransient<IReservationRepository,ReservationRepository>();
            InitializeMapper();
            //  services.AddSwaggerGen(c =>
            // {
            //     c.SwaggerDoc("v1", new Info
            //     {
            //         Version = "v1",
            //         Title = "Hotels GraphQL API Documentation",
            //         Description = "Hotels API",
            //         TermsOfService = "None",
            //         Contact = new Contact() { Name = "hotels", Email = "hotels@hotels.com.ng", Url = "" }
            //     });
            // }); 

            //add automapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
             
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }



            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

             //swagger starts
            // app.UseSwagger(c =>
            // {
            //     c.RouteTemplate = "api-docs/{documentName}/swagger.json";
            // });
            // app.UseSwaggerUI(c =>
            // {
            //     c.RoutePrefix = "api-docs";
            //     c.SwaggerEndpoint("v1/swagger.json", "Hotels - API v1");
            // });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
