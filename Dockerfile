FROM --platform=linux/arm64 mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY . .
RUN dotnet restore "backend/CopaDeFilmes.sln"
WORKDIR /src/backend/CopaDeFilmes.API
RUN dotnet publish "CopaDeFilmes.API.csproj" -c Release -o /app/publish

FROM --platform=linux/arm64 mcr.microsoft.com/dotnet/aspnet:3.1 AS final
WORKDIR /app
RUN apt-get update \
    && apt-get install -y --no-install-recommends libicu63 \
    && rm -rf /var/lib/apt/lists/*
ENV LANG en-US.UTF-8
ENV LC_ALL en-US.UTF-8
EXPOSE 5000
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "CopaDeFilmes.API.dll"]
