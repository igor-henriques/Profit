﻿global using AutoMapper;
global using FluentValidation;
global using MediatR;
global using Microsoft.Extensions.Logging;
global using Newtonsoft.Json;
global using Profit.Core.Enum;
global using Profit.Core.Shared;
global using Profit.Domain.Commands.Ingredient.Create;
global using Profit.Domain.Commands.Ingredient.Put;
global using Profit.Domain.Commands.Order.Create;
global using Profit.Domain.Commands.Product.Create;
global using Profit.Domain.Commands.Product.Put;
global using Profit.Domain.Commands.Recipe.Create;
global using Profit.Domain.Commands.Recipe.Put;
global using Profit.Domain.Commands.User.Create;
global using Profit.Domain.Commands.User.Delete;
global using Profit.Domain.Commands.User.Put;
global using Profit.Domain.DTOs;
global using Profit.Domain.Entities;
global using Profit.Domain.Entities.Base;
global using Profit.Domain.Enums;
global using Profit.Domain.Exceptions;
global using Profit.Domain.Extensions;
global using Profit.Domain.Interfaces;
global using Profit.Domain.Interfaces.Models;
global using Profit.Domain.Interfaces.Repositories;
global using Profit.Domain.Interfaces.Repositories.Base;
global using Profit.Domain.Interfaces.Repositories.ReadOnly;
global using Profit.Domain.Interfaces.Services;
global using Profit.Domain.Models;
global using Profit.Domain.Models.Authentication;
global using Profit.Domain.Queries;
global using Profit.Infrastructure.Repository.Repositories;
global using System.Collections.Immutable;
global using System.Diagnostics;
global using System.Linq.Expressions;
global using System.Runtime.CompilerServices;
global using System.Security.Claims;
global using System.Text;
