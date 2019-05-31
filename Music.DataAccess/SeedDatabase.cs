﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Music.DataAccess.Entities;

namespace Music.DataAccess
{
    public class SeedDatabase
    {
        public static async void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<MusicDbContext>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            context.Database.EnsureCreated();

            //if (!context.Users.Any())
            //{
            //    ApplicationUser user = new ApplicationUser()
            //    {
            //        Email = "a@b.com",
            //        SecurityStamp = Guid.NewGuid().ToString(),
            //        UserName = "Artem"
            //    };

            //    await userManager.CreateAsync(user, "Pass123@");

            //    await context.SaveChangesAsync();
            //}
        }
    }
}
