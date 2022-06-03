using Confluent.Kafka;
using microservice1.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace microservice1
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
            string bootstrapServers = Configuration.GetSection("consumer:bootstrapservers").Get<string>();
            string topic = Configuration.GetSection("consumer:topic").Get<string>();
            string groupId = Configuration.GetSection("consumer:groupid").Get<string>();
            var consumerConfig = new ConsumerConfig
            {
                GroupId= groupId,
                BootstrapServers = bootstrapServers,
                AutoOffsetReset= AutoOffsetReset.Earliest
            };

            //Configuration.Bind("consumer", consumerConfig);
            services.AddDbContext<StudentDbContext>(options =>
            options.UseSqlServer(
                Configuration.GetConnectionString("DefaultConnection")
                ));
            services.AddSingleton<ConsumerConfig>(consumerConfig);
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "microservice1", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "microservice1 v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
