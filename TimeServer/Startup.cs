using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OnTimeData;

namespace TimeServer
{
    public class Startup
    {
        private readonly string conn =
            "Data Source=sql2k802.discountasp.net;Initial Catalog=SQL2008_741027_jerry;Persist Security Info=True;User ID=SQL2008_741027_jerry_user;Password=Gianluca12!";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            

            services.AddCors(o => o.AddPolicy("AllPolicy", b =>
            {
                b.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
            }));

            services.AddControllers();
            services.AddSwaggerGen();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Time Server V1");
            });

          
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("AllPolicy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
