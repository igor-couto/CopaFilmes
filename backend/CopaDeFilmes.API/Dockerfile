FROM --platform=linux/arm64 mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["CopaDeFilmes.API/CopaDeFilmes.API.csproj", "CopaDeFilmes.API/"]
RUN dotnet restore "CopaDeFilmes.API/CopaDeFilmes.API.csproj"
COPY . .
WORKDIR "/src/CopaDeFilmes.API"
RUN dotnet publish "CopaDeFilmes.API.csproj" -c Release -o /app/publish

FROM --platform=linux/arm64 mcr.microsoft.com/dotnet/aspnet:3.1 AS final
WORKDIR /app
EXPOSE 5000
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "CopaDeFilmes.API.dll"]