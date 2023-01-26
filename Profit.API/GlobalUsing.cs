﻿global using FluentValidation;
global using Profit.API.Endpoints;
global using Profit.DependencyInjection.Injectors;
global using System.Net;
global using System.Text.Json;
global using Serilog;
global using Microsoft.EntityFrameworkCore;
global using Profit.Infrastructure.Repository.DataContext;
global using static Profit.Core.Constants;
global using ExceptionHandlerMiddleware = Profit.API.Middlewares.ExceptionHandlerMiddleware;
