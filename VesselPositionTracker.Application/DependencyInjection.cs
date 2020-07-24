﻿using System.Reflection;
using AutoMapper;
using FluentValidation;
using MediatR;

using Microsoft.Extensions.DependencyInjection;
using TaskManagementApp.Application.Common.Behaviors;

namespace VesselPositionTracker.Application
{
   public static class DependencyInjection
    {

        public static IServiceCollection AddApplication(this IServiceCollection services)
        {

            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
