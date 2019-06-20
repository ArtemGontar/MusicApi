using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Music.DataAccess.Entities;
using System;

namespace Music.DataAccess
{
    public class SeedDatabase
    {
        public static async void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<AuthContext>();
            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
            
        }
    }
}
