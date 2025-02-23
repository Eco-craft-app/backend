﻿using Carter;
using FluentValidation;
using MediatR.NotificationPublishers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Modules.Users.Database;
using Modules.Users.Features;
using Modules.Users.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Users.Extensions;
internal static class ServiceCollectionExtensions
{
    internal static void AddUsersModuleServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddUsersProfilesDatabase(configuration);
        services.AddServices(configuration);

    }


    private static void AddUsersProfilesDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<UsersProfilesDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("RecycleDb"));
        });
    }

    private static void AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHttpContextAccessor();
        services.AddScoped<IUserContextService, UserContextService>();
        var assembly = typeof(AddUserProfile).Assembly;
        services.AddValidatorsFromAssembly(assembly);
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(assembly);
            config.NotificationPublisher = new ForeachAwaitPublisher();
        });
    }




}
