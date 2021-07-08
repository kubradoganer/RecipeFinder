#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/RecipeFinder.Api/RecipeFinder.Api.csproj", "src/RecipeFinder.Api/"]
COPY ["src/RecipeFinder.Infrastructure/RecipeFinder.Infrastructure.csproj", "src/RecipeFinder.Infrastructure/"]
COPY ["src/RecipeFinder.Domain/RecipeFinder.Domain.csproj", "src/RecipeFinder.Domain/"]
COPY ["src/RecipeFinder.Application/RecipeFinder.Application.csproj", "src/RecipeFinder.Application/"]
RUN dotnet restore "src/RecipeFinder.Api/RecipeFinder.Api.csproj"
COPY . .
WORKDIR "/src/src/RecipeFinder.Api"
RUN dotnet build "RecipeFinder.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RecipeFinder.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RecipeFinder.Api.dll"]
