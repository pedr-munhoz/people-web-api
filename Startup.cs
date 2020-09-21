using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using people_web_api.Database;
using people_web_api.Database.NoSQL.MongoDB;
using people_web_api.Database.SQL;
using people_web_api.Models;
using people_web_api.Services;

namespace people_web_api
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
            services.Configure<PeopleDatabaseSettings>(Configuration.GetSection(nameof(PeopleDatabaseSettings)));

            services.Configure<UsersDatabaseSettings>(Configuration.GetSection(nameof(UsersDatabaseSettings)));

            services.AddSingleton<INoSqlDbSettings>(x => x.GetRequiredService<IOptions<PeopleDatabaseSettings>>().Value);

            services.AddSingleton<ISqlDbSettings>(x => x.GetRequiredService<IOptions<UsersDatabaseSettings>>().Value);

            services.AddSingleton<INoSqlDatabaseFactory>(new MongoDatabaseFactory());


            var options = new DbContextOptionsBuilder<BaseDbContext>();
            options.UseNpgsql(Configuration.GetSection("ConnectionStrings")["UsersDbContext"]);

            services.AddSingleton<ServerDbContext>(new ServerDbContext(options.Options));

            services.AddSingleton<PersonService>();

            services.AddSingleton<UserService>();

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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
