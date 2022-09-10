using HotelFinder.Business.Abstract;
using HotelFinder.Business.Concrete;
using HotelFinder.DataAccess.Abstract;
using HotelFinder.DataAccess.Concrete;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelFinder.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddControllers();
            //birisi senin constructor inde IHotelService istioyorsa ona hotelmanager �ret demek
            //bunuda controller i�inde kulland�k 
            /*
             * //hotelbusinesstan bir �rnek laz�m
               private IHotelService _hotelService;
              public HotelsController(IHotelService hotelService)
              {
                //hotelServise e de�er atamas� yap
                _hotelService = hotelService;
        }
             */
            services.AddSingleton<IHotelService, HotelManager>();
            //birisi senin constructor inde IHotelRepository istioyorsa ona hotelreposiyory �ret demek new le yani
            services.AddSingleton<IHotelRepository, HotelRepository>();
            //dependency injection i�in business katman�nda HotelManager ctor daki IHotelRepository hotelRepository parametresi al�r
            /*
             *  private IHotelRepository _hotelRepository;
             //dependency injection gere�i bu �ekilde kullan�l�r
              public HotelManager(IHotelRepository hotelRepository)
               {
                   _hotelRepository =hotelRepository;
               }
                */
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
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
