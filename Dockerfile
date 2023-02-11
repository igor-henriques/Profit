#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 6000
EXPOSE 6001
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Profit.API/Profit.API.csproj", "Profit.API/"]
COPY ["Profit.Core/Profit.Core.csproj", "Profit.Core/"]
COPY ["Profit.DependencyInjection/Profit.DependencyInjection.csproj", "Profit.DependencyInjection/"]
COPY ["Profit.Domain/Profit.Domain.csproj", "Profit.Domain/"]
COPY ["Profit.Infrastructure.Repository/Profit.Infrastructure.Repository.csproj", "Profit.Infrastructure.Repository/"]
COPY ["Profit.Infrastructure.Service/Profit.Infrastructure.Service.csproj", "Profit.Infrastructure.Service/"]
RUN dotnet restore "Profit.API/Profit.API.csproj"
COPY . .
WORKDIR "/src/Profit.API"
RUN dotnet build "Profit.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Profit.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
ENV ASPNETCORE_URLS=http://+:6000;https://+:6001
CMD [ "dotnet dev-certs https --trust" ]
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Profit.API.dll"]