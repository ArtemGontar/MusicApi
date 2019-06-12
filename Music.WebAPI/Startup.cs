using BussinessLogic.Services.Implementations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Music.BussinessLogic.Services.Implementations;
using Music.BussinessLogic.Services.Interfaces;
using Music.DataAccess;
using Music.DataAccess.Entities;
using Music.DataAccess.Repositories.Implementations;
using Music.DataAccess.Repositories.Interfaces;
using Music.WebAPI.Infrastructure;
using Serilog;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace Music.WebAPI
{
    /// <summary>
    /// Startuo class
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Constructor startup class
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            // Init Serilog configuration
            Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        /// <summary>
        /// Configure services
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<MusicDbContext>();
            services.AddScoped<ISongRepository, SongRepository>();
            services.AddScoped<ISongService, SongService>();
            services.AddScoped<IArtistRepository, ArtistRepository>();
            services.AddScoped<IArtistService, ArtistService>();
            services.AddScoped<IAlbumRepository, AlbumRepository>();
            services.AddScoped<IAlbumService, AlbumService>();
            services.AddScoped<IGroupRepository, GroupRepository>();
            services.AddScoped<IGroupService, GroupService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();


            services.AddSwaggerGen(options =>
            {
                options.DescribeAllEnumsAsStrings();
                options.SwaggerDoc("v1", new Info
                {
                    Title = "POD HTTP API",
                    Version = "v1"
                });

                options.AddSecurityDefinition("Bearer", new Swashbuckle.AspNetCore.Swagger.ApiKeyScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = "header",
                    Type = "apiKey"
                });
                var security = new Dictionary<string, IEnumerable<string>>
                {
                    {"Bearer", new string[] { }},
                };
                options.AddSecurityRequirement(security);

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);
                
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,

                        ValidIssuer = Configuration.GetSection("Authentication:Issuer").Value,
                        ValidAudience = Configuration.GetSection("Authentication:Audience").Value,
                        IssuerSigningKey = JwtSecurityKey.Create(Configuration.GetSection("Authentication:SecurityKey").Value)
                    };

                    options.Events = new JwtBearerEvents
                    {
                        OnAuthenticationFailed = context =>
                        {
                            Console.WriteLine("OnAuthenticationFailed: " + context.Exception.Message);
                            return Task.CompletedTask;
                        },
                        OnTokenValidated = context =>
                        {
                            Console.WriteLine("OnTokenValidated: " + context.SecurityToken);
                            return Task.CompletedTask;
                        }
                    };
                });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Member",
                    policy => policy.RequireClaim("MembershipId"));
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.Configure<Settings>(options =>
            {
                options.ConnectionString = Configuration.GetSection("MongoConnection:ConnectionString").Value;
                options.Database = Configuration.GetSection("MongoConnection:Database").Value;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// <summary>
        /// Configure
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseAuthentication();
            
            // logging
            loggerFactory.AddSerilog();

            app.UseMvc();
        }
    }
}
